using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lcump.lib;

namespace lcump.Data
{

    public class TTransMatrix //TransMatrix
    {
        //public struct TVector
        //{
        //    public double X, Y, Z;
        //}

        // TTransElement

        public double[,] EL = new double[4, 4];

        // library
        TLeastSquare LeastSquare;
        TAffine Affine;

        public TTransMatrix()
        {
            LeastSquare = new TLeastSquare();
            Affine = new TAffine();
            
        }

        ~TTransMatrix()
        {
            //
        }

        //----------------
        //----------------
        public TVector Vector(double X, double Y, double Z)
        {
            TVector Result = new TVector();

            Result.X = X;
            Result.Y = Y;
            Result.Z = Z;

            return (Result);
        }
        
        //----------------
        //----------------
        public double InnerProduct(TVector V1, TVector V2)
        {
            double Result = (V1.X * V2.X) + (V1.Y * V2.Y) + (V1.Z * V2.Z);

            return (Result);
        }

        //----------------
        //----------------
        public TVector OuterProduct(TVector V1, TVector V2)
        {
            TVector Result = new TVector();

            Result.X = V1.Y * V2.Z - V1.Z * V2.Y;
            Result.Y = V1.Z * V2.X - V1.X * V2.Z;
            Result.Z = V1.X * V2.Y - V1.Y * V2.X;

            return (Result);
        }

        //----------------
        //----------------
        public double SqrVector(TVector V)
        {
            double Result = InnerProduct(V, V);

            return (Result);
        }

        //----------------
        //----------------
        public double NormVector(TVector V)
        {
            double Result = Math.Sqrt(SqrVector(V));

            return (Result);
        }

        //----------------
        //----------------
        public TVector MulVector(TVector V, double K)
        {
            TVector Result = new TVector();

            Result.X = K * V.X;
            Result.Y = K * V.Y;
            Result.Z = K * V.Z;

            return (Result);
        }

        //----------------
        //----------------
        public TVector DivVector(TVector V, double K)
        {
            TVector Result = new TVector();

            Result = MulVector(V, 1 / K);

            return (Result);
        }

        //----------------
        //----------------
        public TVector UnitVector(TVector V)
        {
            TVector Result = new TVector();

            Result = DivVector(V, NormVector(V));

            return (Result);
        }

        //----------------
        //----------------
        public TVector AddVector(TVector V1, TVector V2)
        {
            TVector Result = new TVector();

            Result.X = V1.X + V2.X;
            Result.Y = V1.Y + V2.Y;
            Result.Z = V1.Z + V2.Z;

            return (Result);
        }

        //----------------
        //----------------
        public TVector SubVector(TVector V1, TVector V2)
        {
            TVector Result = new TVector();

            Result.X = V1.X - V2.X;
            Result.Y = V1.Y - V2.Y;
            Result.Z = V1.Z - V2.Z;

            return (Result);
        }

        //----------------
        //----------------
        public double PointToPointDistance(TVector V1, TVector V2)
        {
            double Result = NormVector(SubVector(V1, V2));

            return (Result);
        }

        //----------------
        // 点と直線
        //----------------
        public TVector PointToLinePoint(TVector P, TVector O, TVector S)
        {
            TVector Result = new TVector();
            double K;

            K = InnerProduct(SubVector(P, O), S) / SqrVector(S);

            Result = AddVector(O, MulVector(S, K));

            return (Result);
        }


        //----------------
        //----------------
        public TVector PointToPlanePoint(TVector P, TVector O, TVector S)
        {
            TVector Result = new TVector();

            Result = LineToPlanePoint(P, S, O, S);

            return (Result);
        }


        //-------------------------------------------
        // 直線 P,T 上で直線 O,S に最も近い点を返す
        //-------------------------------------------
        public TVector LineToLinePoint(TVector P, TVector T, TVector O, TVector S)
        {
            TVector Result = new TVector();
            TVector OP = new TVector();
            double SS, TT, TS, K, D;


            OP = SubVector(P, O);
            SS = InnerProduct(S, S);
            TT = InnerProduct(T, T);
            TS = InnerProduct(T, S);
            //D = SS * TT - Sqr(TS);
            D = SS * TT - Math.Pow(TS, 2);

            if (D == 0)
            {
                K = 0;
            }
            else
            {
                K = (InnerProduct(OP, S) * TS - SS * InnerProduct(OP, T)) / D;
            }

            Result = AddVector(P, MulVector(T, K));

            return (Result);
        }


        //-----------------------------------
        // 直線 P,T と平面 O,S の交点を返す
        //-----------------------------------
        public TVector LineToPlanePoint(TVector P, TVector T, TVector O, TVector S)
        {
            TVector Result = new TVector();
            double K, D;

            D = InnerProduct(T, S);

            if (D == 0)
            {
                K = 0;
            }
            else
            {
                K = InnerProduct(SubVector(P, O), S) / D;
            }

            Result = AddVector(P, MulVector(T, K));

            return (Result);
        }


        //////////////////////////////////////////////////////////////////////////////

        //----------------
        //----------------
        public void ClearElement(ref double[,] EL)
        {
            int I, J;

            for (I = 0; I < 4; I++)
            {
                for (J = 0; J < 4; J++)
                {
                    EL[I, J] = 0;
                }
            }
        }


        //----------------
        //----------------
        public void InitElement(ref double[,] EL)
        {
            int I;

            ClearElement(ref EL);

            for (I = 0; I < 4; I++)
            {
                EL[I, I] = 1;
            }
        }


        //----------------
        //----------------
        public double[,] MoveElement(double DX, double DY, double DZ)
        {
            double[,] Result = new double[4, 4];

            InitElement(ref Result);
            Result[3, 0] = DX;
            Result[3, 1] = DY;
            Result[3, 2] = DZ;

            return (Result);
        }


        //----------------
        //----------------
        public double[,] RotateElement(double U1, double U2, double U3, double TH)
        {
            double[,] Result = new double[4, 4];
            double CosT, SinT;
            double K;

            //{$IFDEF DEBUG}
            //  if (Sqr(U1) + Sqr(U2) + Sqr(U3) <> 1) then
            //    raise Exception.Create('回転エラー');
            //{$ENDIF}

            InitElement(ref Result);
            CosT = Math.Cos(TH);
            SinT = Math.Sin(TH);
            K = 1 - CosT;

            Result[0, 0] = K * U1 * U1 + 1 * CosT;
            Result[0, 1] = K * U1 * U2 + U3 * SinT;
            Result[0, 2] = K * U1 * U3 - U2 * SinT;
            Result[1, 0] = K * U2 * U1 - U3 * SinT;
            Result[1, 1] = K * U2 * U2 + 1 * CosT;
            Result[1, 2] = K * U2 * U3 + U1 * SinT;
            Result[2, 0] = K * U3 * U1 + U2 * SinT;
            Result[2, 1] = K * U3 * U2 - U1 * SinT;
            Result[2, 2] = K * U3 * U3 + 1 * CosT;

            return (Result);
        }


        //----------------
        //----------------
        public double[,] ScaleElement(double K1, double K2, double K3)
        {
            double[,] Result = new double[4, 4];

            InitElement(ref Result);

            Result[0, 0] = K1;
            Result[1, 1] = K2;
            Result[2, 2] = K3;

            return (Result);
        }


        //----------------
        //----------------
        //public void TTransMatrix.Copy(TTransMatrix Src)
        public void Copy(TTransMatrix Src)
        {
            int I, J;

            for (I = 0; I < 4; I++)
            {
                for (J = 0; J < 4; J++)
                {
                    this.EL[I, J] = Src.EL[I, J];
                }
            }
        }


        //----------------
        //----------------
        //public void TTransMatrix.Clear()
        public void Clear()
        {
            ClearElement(ref this.EL);
        }


        //----------------
        //----------------
        //public void TTransMatrix.Init()
        public void Init()
        {
            InitElement(ref this.EL);
        }


        //----------------
        // 変換
        //----------------
        //public TVector TTransMatrix.Trans(TVector PT)
        public TVector Trans(TVector PT)
        {
            TVector Result = new TVector();

            Result.X = PT.X * EL[0, 0] + PT.Y * EL[1, 0] + PT.Z * EL[2, 0] + 1 * EL[3, 0];
            Result.Y = PT.X * EL[0, 1] + PT.Y * EL[1, 1] + PT.Z * EL[2, 1] + 1 * EL[3, 1];
            Result.Z = PT.X * EL[0, 2] + PT.Y * EL[1, 2] + PT.Z * EL[2, 2] + 1 * EL[3, 2];

            return (Result);
        }


        //----------------
        // 変換追加
        //----------------
        /*
           Self M
         |..J..||.    |
         |.    ||.    |
         |I    ||K    |
         |.    ||.    |
        */

        //public void TTransMatrix.Mul(TTransMatrix TM)
        public void Mul(TTransMatrix TM)
        {
            Mul(TM.EL);
        }

        //----------------
        //----------------
        //public void TTransMatrix.Mul(doublie[,] TE)
        public void Mul(double[,] TE)
        {
            double[] T = new double[4];
            int I, J, K;

            for (I = 0; I < 4; I++)
            {
                for (J = 0; J < 4; J++)
                {
                    T[J] = 0;

                    for (K = 0; K < 4; K++)
                    {
                        T[J] = T[J] + EL[I, K] * TE[K, J];
                    }
                }
                for (K = 0; K < 4; K++)
                {
                    EL[I, K] = T[K];
                }

            }
        }

        //----------------
        // 平行移動追加
        //----------------
        public void Move(double DX, double DY, double DZ)
        {
            Mul(MoveElement(DX, DY, DZ));
        }

        //----------------
        // 回転変換追加
        //----------------
        //procedure TTransMatrix.RotateX(Rad: Double);
        //begin
        //  Rotate(1, 0, 0, Rad);
        //end;

        public void RotateX(double Rad)
        {
            Rotate(1, 0, 0, Rad);
        }


        //----------------
        //
        //----------------
        //procedure TTransMatrix.RotateY(Rad: Double);
        //begin
        //  Rotate(0, 1, 0, Rad);
        //end;

        public void RotateY(double Rad)
        {
            Rotate(0, 1, 0, Rad);
        }

        //----------------
        //
        //----------------
        //procedure TTransMatrix.RotateZ(Rad: Double);
        //begin
        //  Rotate(0, 0, 1, Rad);
        //end;

        public void RotateZ(double Rad)
        {
            Rotate(0, 0, 1, Rad);
        }

        //----------------
        //
        //----------------
        //procedure TTransMatrix.Rotate(U1, U2, U3: Double; Rad: Double);
        //begin
        //   Mul(RotateElement(U1, U2, U3, Rad));
        //end;

        public void Rotate(double U1, double U2, double U3, double Rad)
        {
            Mul(RotateElement(U1, U2, U3, Rad));
        }

        //----------------
        //
        //----------------
        //procedure TTransMatrix.Tilt(XRad, YRad: Double);
        //var
        //  DX, DY, DXY: Double;
        //begin
        //  DX := Tan(XRad);
        //  DY := Tan(YRad);
        //  DXY := Sqrt(Sqr(DX) + Sqr(DY));
        //  if (DXY<> 0) then
        //      Rotate(-DY / DXY, DX / DXY, 0, ArcTan(DXY));
        //end;

        public void Tilt(double XRad, double YRad)
        {
            double DX, DY, DXY;

            DX = Math.Tan(XRad);
            DY = Math.Tan(YRad);
            DXY = Math.Sqrt(Math.Pow(DX, 2) + Math.Pow(DY, 2));
            if (DXY != 0)
            {
                Rotate(-DY / DXY, DX / DXY, 0, Math.Atan(DXY));
            }
        }

        //----------------
        //
        //----------------
        //procedure TTransMatrix.Scale(K1, K2, K3: Double);
        //begin
        //  Mul(ScaleElement(K1, K2, K3));
        //end;

        public void Scale(double K1, double K2, double K3)
        {
            Mul(ScaleElement(K1, K2, K3));
        }

        //----------------
        //
        //----------------
        //procedure TTransMatrix.Scale(K: Double);
        //begin
        //  Scale(K, K, K);
        //end;

        public void Scale(double K)
        {
            Scale(K, K, K);
        }

        //----------------
        //
        //----------------
        //procedure TTransMatrix.Inverse;
        //const
        //    N = 4;
        //    M = 4;
        //var
        //  A: TMatrix;
        //  B, X: array of Double;
        //  IP: array of Integer;
        //  G2, RD, CO: array of Double;
        //  Inv: TTransMatrix;
        //
        //procedure CalcColumn(Index: Integer);
        //var
        //I: Integer;
        //  ///    Rank: Integer;
        //begin
        //  for I := 0 to N - 1 do
        //  begin
        //      A[I, 0] := EL[I, 0];
        //      A[I, 1] := EL[I, 1];
        //      A[I, 2] := EL[I, 2];
        //      A[I, 3] := EL[I, 3];
        //      if (I = Index) then
        //          B[I] := 1
        //      else
        //       B[I] := 0;
        //  end;
        //
        //  ///    LeastSquare(N, M, A, B, X, Rank, IP, G2, RD, CO);
        //  LeastSquare(A, B, X);
        //  for I := 0 to M - 1 do
        //      Inv.EL[I, Index] := X[I];
        //end;
        //var
        //  J: Integer;
        //begin
        //  SetLength(A, N, M);
        //  SetLength(X, M);
        //  SetLength(G2, M);
        //  SetLength(RD, M);
        //  SetLength(CO, M);
        //  SetLength(B, N);
        //  SetLength(IP, M);
        //  Inv := TTransMatrix.Create;
        //  try
        //      for J := 0 to M - 1 do
        //          CalcColumn(J);
        //      Copy(Inv);
        //  finally
        //      Inv.Free;
        //  end;
        //  {
        //      X := DX;
        //      Y := DY;
        //      Z := DZ;
        //      A := DA;
        //      B := DB;
        //      C := DC;
        //      Init;
        //      Move(-X, -Y, -Z);
        //      RotateX(-A);
        //      RotateY(-B);
        //      RotateZ(-C);
        //  }
        //  end;
        //

        const int N = 4;
        const int M = 4;

        public void CalcColumn(
            int Index,
            ref TMatrix A,
            ref double[] B,
            ref double[] X,
            ref TTransMatrix Inv)
        {
            int I;
            //    Rank: Integer;

            for (I = 0; I < N; I++)
            {
                A[I, 0] = EL[I, 0];
                A[I, 1] = EL[I, 1];
                A[I, 2] = EL[I, 2];
                A[I, 3] = EL[I, 3];
                if (I == Index)
                {
                    B[I] = 1;
                }
                else
                {
                    B[I] = 0;
                }
            }

            ///    LeastSquare(N, M, A, B, X, Rank, IP, G2, RD, CO);
            LeastSquare.LeastSquare(ref A, ref B, ref X);

            for (I = 0; I < M; I++)
            {
                Inv.EL[I, Index] = X[I];
            }
        }


        public void Inverse()
        {
            //double[,] A;
            TMatrix A;
            double[] B, X;
            int[] IP;
            double[] G2, RD, CO;
            TTransMatrix Inv;

            int J;

            //A = new double[N, M];
            A = new TMatrix(N, M);

            X = new double[M];
            G2 = new double[M];
            RD = new double[M];
            CO = new double[M];
            B = new double[N];
            IP = new int[M];
            Inv = new TTransMatrix();

            try
            {
                for (J = 0; J < M; J++)
                {
                    CalcColumn(J,ref A,ref B,ref X, ref Inv);
                }
                Copy(Inv);
            }
            finally
            {
                //Inv.Free;
                GC.Collect();
            }
            //{
            //X := DX;
            //Y := DY;
            //Z := DZ;
            //A := DA;
            //B := DB;
            //C := DC;
            //Init;
            //Move(-X, -Y, -Z);
            //RotateX(-A);
            //RotateY(-B);
            //RotateZ(-C);
            //}
        }

        //----------------
        //----------------
        //function TTransMatrix.DX: Double;
        //begin
        //  Result := EL[3, 0];
        //    end;
        public double DX()
        {
            double Result = EL[3, 0];

            return (Result);
        }

        //----------------
        //----------------
        //function TTransMatrix.DY: Double;
        //begin
        //  Result := EL[3, 1];
        //end;
        public double DY()
        {
            double Result = EL[3, 1];

            return (Result);
        }

        //----------------
        //----------------
        //function TTransMatrix.DZ: Double;
        //begin
        //  Result := EL[3, 2];
        //end;
        public double D()
        {
            double Result = EL[3, 2];

            return (Result);
        }

        //----------------
        //----------------
        //function TTransMatrix.DA: Double;
        //begin
        //  Result := ArcSin(EL[1, 2]);
        //end;
        public double DA()
        {
            double Result = Math.Asin(EL[1, 2]);

            return (Result);
        }

        //----------------
        //----------------
        //function TTransMatrix.DB: Double;
        //begin
        //  Result := ArcSin(EL[2, 0]);
        //end;
        public double DB()
        {
            double Result = Math.Asin(EL[2, 0]);

            return (Result);
        }

        //----------------
        //----------------
        //function TTransMatrix.DC: Double;
        //begin
        //  Result := ArcSin(EL[0, 1]);
        //end;

        public double DC()
        {
            double Result = Math.Asin(EL[0, 1]);

            return (Result);
        }


    }
}
