using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using TVectorArray = System.Single;
using TAffineElement = System.Double;

namespace lcump.lib
{

    public class TVector
    {
        public double X, Y, Z;

        public TVector()
        {
            X = 0.0;
            Y = 0.0;
            Z = 0.0;
        }

        public TVector(double _X,double _Y, double _Z)
        {
            X = _X;
            Y = _Y;
            Z = _Z;
        }

    }

    public class TAffine
    {

        /*
                [StructLayout(LayoutKind.Explicit)]
                public struct TVector
                {
                    [FieldOffset(0)]
                    public Single X;
                    [FieldOffset(1)]
                    public Single Y;
                    [FieldOffset(2)]
                    //public Single W;
                    public Single Z;
                    [FieldOffset(0)]
                    public TVectorArray[] V;
                }
        */


        //TVector = record
        //   X, Y, Z: Double;
        //end;
        //
        //TAffineParam = record
        //  X, Y, Z, RotX, RotY, RotZ: Double;
        //end;



        public struct TAffineParam
        {
            public double X, Y, Z, RotX, RotY, RotZ;
        }

        //TAffineElement = array[0..3, 0..3] of Double;

        /*
        TAffine = class
        private
    function GetParam: TAffineParam;
    procedure SetParam(const Value: TAffineParam);
    procedure SetX(const Value: Double);
    procedure SetY(const Value: Double);
    procedure SetZ(const Value: Double);
    function GetX: Double;
    function GetY: Double;
    function GetZ: Double;
  public
    EL: TAffineElement;
    constructor Create;
        procedure Copy(const Src: TAffine);
    procedure Clear;
        procedure Init;
        function Trans(const PT: TVector): TVector;
    procedure Mul(const TE: TAffineElement); overload;
    procedure Mul(const TM: TAffine); overload;
    procedure MulBefore(const TE: TAffineElement); overload;
    procedure MulBefore(const TM: TAffine); overload;
    procedure Move(DX, DY, DZ: Double);
        procedure MoveBefore(DX, DY, DZ: Double);
        procedure RotateX(Rad: Double);
        procedure RotateY(Rad: Double);
        procedure RotateZ(Rad: Double);
        procedure RotateXBefore(Rad: Double);
        procedure RotateYBefore(Rad: Double);
        procedure RotateZBefore(Rad: Double);
        procedure Rotate(U1, U2, U3: Double; Rad: Double);
    procedure RotateBefore(U1, U2, U3: Double; Rad: Double);
    procedure Tilt(XRad, YRad: Double);
        procedure TiltBefore(XRad, YRad: Double);
        procedure Scale(K1, K2, K3: Double); overload;
    procedure ScaleBefore(K1, K2, K3: Double); overload;
    procedure Scale(K: Double); overload;
    procedure ScaleBefore(K: Double); overload;
    procedure Inverse;
        property X: Double read GetX write SetX;
    property Y: Double read GetY write SetY;
    property Z: Double read GetZ write SetZ;
    function RotX: Double;
    function RotY: Double;
    function RotZ: Double;
    function ScaleX: Double;
    function ScaleY: Double;
    function ScaleZ: Double;
    property Param: TAffineParam read GetParam write SetParam;
    procedure Add(AP: TAffineParam);
        procedure AddBefore(AP: TAffineParam);
        procedure Delete(AP: TAffineParam);
        procedure DeleteBefore(AP: TAffineParam);
        end;
        */


        //    property X: Double read GetX write SetX;
        //    property Y: Double read GetY write SetY;
        //    property Z: Double read GetZ write SetZ;

        public double X
        {
            get { return GetX(); }
            protected set { SetX(value); }
        }

        public double Y
        {
            get { return GetY(); }
            protected set { SetY(value); }
        }

        public double Z
        {
            get { return GetZ(); }
            protected set { SetZ(value); }
        }


        //const
        //ZeroVector: TVector = (X: 0; Y: 0; Z: 0);
        //XVector: TVector = (X: 1; Y: 0; Z: 0);
        //YVector: TVector = (X: 0; Y: 1; Z: 0);
        //ZVector: TVector = (X: 0; Y: 0; Z: 1);

        TVector ZeroVector = new TVector( 0.0, 0.0, 0.0 );
        TVector XVector = new TVector ( 1.0, 0.0, 0.0 );
        TVector YVector = new TVector ( 0.0, 1.0, 0.0 );
        TVector ZVector = new TVector ( 0.0, 0.0, 1.0 );


        //const
        //  DBL_EPSILON = 2.2204460492503131E-16;

        public const double DBL_EPSILON = 2.2204460492503131E-16;

        public TAffineElement[,] EL = new TAffineElement[4, 4];

        //----------------
        //----------------
        //function Vector(X, Y, Z: Double): TVector;
        //begin
        //  Result.X := X;
        //  Result.Y := Y;
        //  Result.Z := Z;
        //end;

        public TVector Vector(double X, double Y, double Z)
        {
            TVector Result = new TVector(X,Y,Z);

            return (Result);
        }


        //----------------
        //----------------
        //function AffineParam(X, Y, Z, RotX, RotY, RotZ: Double): TAffineParam;
        //begin
        //  Result.X := X;
        //  Result.Y := Y;
        //  Result.Z := Z;
        //  Result.RotX := RotX;
        //  Result.RotY := RotY;
        //  Result.RotZ := RotZ;
        //end;
        public TAffineParam AffineParam(double X, double Y, double Z, double RotX, double RotY, double RotZ)
        {
            TAffineParam Result = new TAffineParam
            {
                X = X,
                Y = Y,
                Z = Z,
                RotX = RotX,
                RotY = RotY,
                RotZ = RotZ
            };

            /*
            TAffineParam Result = new TAffineParam();
            Result.X = X;
            Result.Y = Y;
            Result.Z = Z;
            Result.RotX = RotX;
            Result.RotY = RotY;
            Result.RotZ = RotZ;
            */

            return (Result);
        }


        //----------------
        //----------------
        //function InnerProduct(const V1, V2: TVector): Double;
        //begin
        //  Result := (V1.X* V2.X) + (V1.Y* V2.Y) + (V1.Z* V2.Z);
        //end;

        public double InnerProduct(TVector V1, TVector V2)
        {
            double Result = (V1.X * V2.X) + (V1.Y * V2.Y) + (V1.Z * V2.Z);

            return (Result);
        }


        //----------------
        //----------------
        //function OuterProduct(const V1, V2: TVector): TVector;
        //begin
        //  Result.X := V1.Y* V2.Z - V1.Z* V2.Y;
        //  Result.Y := V1.Z* V2.X - V1.X* V2.Z;
        //  Result.Z := V1.X* V2.Y - V1.Y* V2.X;
        //end;

        public TVector OuterProduct(TVector V1, TVector V2)
        {
            TVector Result = new TVector();


            Result.X = V1.Y * V2.Z - V1.Z * V2.Y;
            Result.Y = V1.Z * V2.X - V1.X * V2.Z;
            Result.Z = V1.X * V2.Y - V1.Y * V2.X;

            /*
            TVector Result = new TVector();
            Result.X = V1.Y * V2.Z - V1.Z * V2.Y;
            Result.Y = V1.Z * V2.X - V1.X * V2.Z;
            Result.Z = V1.X * V2.Y - V1.Y * V2.X;
            */

            return (Result);
        }



        //----------------
        //----------------
        //function SqrVector(const V: TVector): Double;
        //begin
        //  Result := InnerProduct(V, V);
        //end;

        public double SqrVector(TVector V)
        {
            double Result = InnerProduct(V, V);

            return (Result);
        }


        //----------------
        //----------------
        //function NormVector(const V: TVector): Double;
        //begin
        //  Result := Sqrt(SqrVector(V));
        //end;

        public double NormVector(TVector V)
        {
            double Result = Math.Sqrt(SqrVector(V));

            return (Result);
        }


        //----------------
        //----------------
        //function MulVector(const V: TVector; K: Double): TVector;
        //begin
        //  Result.X := K* V.X;
        //  Result.Y := K* V.Y;
        //  Result.Z := K* V.Z;
        //end;

        public TVector MulVector(TVector V, double K)
        {
            TVector Result = new TVector
            {
                X = K * V.X,
                Y = K * V.Y,
                Z = K * V.Z
            };

            return (Result);
        }


        //----------------
        //----------------
        //function DivVector(const V: TVector; K: Double): TVector;
        //begin
        //  Result := MulVector(V, 1 / K);
        //end;

        public TVector DivVector(TVector V, double K)
        {
            TVector Result = MulVector(V, 1 / K);

            return (Result);
        }


        //----------------
        //----------------
        //function UnitVector(const V: TVector): TVector;
        //begin
        //  Result := DivVector(V, NormVector(V));
        //end;

        public TVector UnitVector(TVector V)
        {
            TVector Result = DivVector(V, NormVector(V));

            return (Result);
        }

        //----------------
        //----------------
        //function AddVector(const V1, V2: TVector): TVector;
        //begin
        //  Result.X := V1.X + V2.X;
        //  Result.Y := V1.Y + V2.Y;
        //  Result.Z := V1.Z + V2.Z;
        //end;

        public TVector AddVector(TVector V1, TVector V2)
        {
            TVector Result = new TVector
            {
                X = V1.X + V2.X,
                Y = V1.Y + V2.Y,
                Z = V1.Z + V2.Z
            };

            return (Result);
        }


        //----------------
        //----------------
        //function SubVector(const V1, V2: TVector): TVector;
        //begin
        //  Result.X := V1.X - V2.X;
        //  Result.Y := V1.Y - V2.Y;
        //  Result.Z := V1.Z - V2.Z;
        //end;

        public TVector SubVector(TVector V1, TVector V2)
        {
            TVector Result = new TVector
            {
                X = V1.X - V2.X,
                Y = V1.Y - V2.Y,
                Z = V1.Z - V2.Z
            };

            return (Result);
        }


        //----------------
        //----------------
        //function PointToPointDistance(const V1, V2: TVector): Double;
        //begin
        //    Result := NormVector(SubVector(V1, V2));
        //end;

        public double PointToPointDistance(TVector V1, TVector V2)
        {
            double Result = NormVector(SubVector(V1, V2));

            return (Result);
        }


        //----------------
        // 点と直線
        //----------------
        //function PointToLinePoint(const P: TVector; const O, S: TVector): TVector;
        //var
        //  K: Double;
        //begin
        //  K := InnerProduct(SubVector(P, O), S) / SqrVector(S);
        //  Result := AddVector(O, MulVector(S, K));
        //end;

        public TVector PointToLinePoint(TVector P, TVector O, TVector S)
        {
            double K = InnerProduct(SubVector(P, O), S) / SqrVector(S);

            TVector Result = AddVector(O, MulVector(S, K));

            return (Result);
        }


        //----------------
        //----------------
        //function PointToPlanePoint(const P: TVector; const O, S: TVector): TVector;
        //begin
        //  Result := LineToPlanePoint(P, S, O, S);
        //end;

        public TVector PointToPlanePoint(TVector P, TVector O, TVector S)
        {
            TVector Result = LineToPlanePoint(P, S, O, S);

            return (Result);
        }


        //-------------------------------------------
        // 直線 P,T 上で直線 O,S に最も近い点を返す
        //-------------------------------------------
        //function LineToLinePoint(const P, T: TVector; const O, S: TVector): TVector;
        //var
        //  OP: TVector;
        //  SS, TT, TS, K, D: Double;
        //begin
        //  OP := SubVector(P, O);
        //  SS := InnerProduct(S, S);
        //  TT := InnerProduct(T, T);
        //  TS := InnerProduct(T, S);
        //  D := SS* TT - Sqr(TS);
        //  if (D = 0) then
        //      K := 0
        //  else
        //      K := (InnerProduct(OP, S) * TS - SS* InnerProduct(OP, T)) / D;
        //
        //  Result := AddVector(P, MulVector(T, K));
        //end;

        public TVector LineToLinePoint(TVector P, TVector T, TVector O, TVector S)
        {
            TVector Result, OP;
            double SS, TT, TS, K, D;

            OP = SubVector(P, O);
            SS = InnerProduct(S, S);
            TT = InnerProduct(T, T);
            TS = InnerProduct(T, S);
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


        //----------------
        // 直線 P,T と平面 O,S の交点を返す
        //----------------
        //function LineToPlanePoint(const P, T: TVector; const O, S: TVector): TVector;
        // P,T 直線上の点と方向ベクトル
        // O,S 平面上の点と法線ベクトル
        //var
        //  K, D: Double;
        //begin
        //  D := InnerProduct(T, S);
        //  if (D = 0) then
        //      K := 0
        //  else
        //      K := InnerProduct(SubVector(O, P), S) / D;
        //
        //  Result := AddVector(P, MulVector(T, K));
        //end;

        public TVector LineToPlanePoint(TVector P, TVector T, TVector O, TVector S)
        {
            TVector Result;
            double K, D;

            D = InnerProduct(T, S);

            if (D == 0)
            {
                K = 0;
            }
            else
            {
                K = InnerProduct(SubVector(O, P), S) / D;
            }

            Result = AddVector(P, MulVector(T, K));

            return (Result);
        }



        //---------------------------------------
        // 平面式 A * X + B * Y + C * Z + D = 0
        // ベクトル式 原点 O 法線 S
        // 変換
        //---------------------------------------
        //procedure PlaneParamToPlaneVector(var O, S: TVector; A, B, C, D: Double);
        //begin
        //  S := Vector(A, B, C);
        //  O := MulVector(S, -D / SqrVector(S));
        //  S := UnitVector(S);
        //end;

        public void PlaneParamToPlaneVector(ref TVector O, ref TVector S,
                                                        double A, double B, double C, double D)
        {
            S = Vector(A, B, C);
            O = MulVector(S, -D / SqrVector(S));
            S = UnitVector(S);
        }


        //----------------
        // ベクトル式 原点 O 法線 S
        // 平面式 A * X + B * Y + C * Z + D = 0
        // 変換
        //----------------
        //procedure PlaneVectorToPlaneParam(var A, B, C, D: Double; const O, S: TVector);
        //begin
        //  A := S.X;
        //  B := S.Y;
        //  C := S.Z;
        //  D := -InnerProduct(O, S);
        //end;

        public void PlaneVectorToPlaneParam(ref double A, ref double B, ref double C, ref double D,
                                                                                         TVector O, TVector S)
        {
            A = S.X;
            B = S.Y;
            C = S.Z;
            D = -InnerProduct(O, S);
        }


        //////////////////////////////////////////////////////////////////////////////


        //----------------
        //----------------
        //procedure ClearElement(var EL: TAffineElement);
        //var
        //  I, J: Integer;
        //begin
        //  for I := 0 to 3 do
        //      for J := 0 to 3 do
        //          EL[I, J] := 0;
        //end;

        public void ClearElement(ref TAffineElement[,] EL)
        {
            int I, J;

            for (I = 0; I < EL.GetLength(0); I++)
            {
                for (J = 0; J < EL.GetLength(1); J++)
                {
                    EL[I, J] = 0;
                }
            }
        }


        //----------------
        //----------------
        //procedure InitElement(var EL: TAffineElement);
        //var
        //  I: Integer;
        //begin
        //  ClearElement(EL);
        //  for I := 0 to 3 do
        //      EL[I, I] := 1;
        //end;

        public void InitElement(ref TAffineElement[,] EL)
        {
            int I, J;

            ClearElement(ref EL);

            J = Math.Min(EL.GetLength(0), EL.GetLength(1));

            for (I = 0; I < J; I++)
            {
                EL[I, I] = 1;
            }
        }



        //----------------
        //----------------
        //function MoveElement(DX, DY, DZ: Double): TAffineElement;
        //begin
        //  InitElement(Result);
        //  Result[3, 0] := DX;
        //  Result[3, 1] := DY;
        //  Result[3, 2] := DZ;
        //end;

        public TAffineElement[,] MoveElement(double DX, double DY, double DZ)
        {
            TAffineElement[,] Result = new TAffineElement[4, 4];

            InitElement(ref Result);

            Result[3, 0] = DX;
            Result[3, 1] = DY;
            Result[3, 2] = DZ;

            return (Result);
        }


        //----------------
        //----------------
        //function RotateElement(U1, U2, U3: Double; TH: Double): TAffineElement;
        //var
        //  CosT, SinT: Double;
        //  K, L: Double;
        //begin
        //  L := Sqrt(Sqr(U1) + Sqr(U2) + Sqr(U3));
        //  U1 := U1 / L;
        //  U2 := U2 / L;
        //  U3 := U3 / L;
        //
        //  InitElement(Result);
        //  CosT := Cos(TH);
        //  SinT := Sin(TH);
        //  K := 1 - CosT;
        //
        //  Result[0, 0] := K* U1 * U1 +  1 * CosT;
        //  Result[0, 1] := K* U1 * U2 + U3* SinT;
        //  Result[0, 2] := K* U1 * U3 - U2* SinT;
        //  Result[1, 0] := K* U2 * U1 - U3* SinT;
        //  Result[1, 1] := K* U2 * U2 +  1 * CosT;
        //  Result[1, 2] := K* U2 * U3 + U1* SinT;
        //  Result[2, 0] := K* U3 * U1 + U2* SinT;
        //  Result[2, 1] := K* U3 * U2 - U1* SinT;
        //  Result[2, 2] := K* U3 * U3 +  1 * CosT;
        //end;

        public TAffineElement[,] RotateElement(double U1, double U2, double U3, double TH)
        {
            TAffineElement[,] Result = new TAffineElement[4, 4];
            double CosT, SinT;
            double K, L;

            L = Math.Sqrt(Math.Pow(U1, 2) + Math.Pow(U2, 2) + Math.Pow(U3, 2));
            U1 = U1 / L;
            U2 = U2 / L;
            U3 = U3 / L;

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
        //function ScaleElement(K1, K2, K3: Double): TAffineElement;
        //begin
        //  InitElement(Result);
        //  Result[0, 0] := K1;
        //  Result[1, 1] := K2;
        //  Result[2, 2] := K3;
        //end;

        public TAffineElement[,] ScaleElement(double K1, double K2, double K3)
        {
            TAffineElement[,] Result = new TAffineElement[4, 4];

            InitElement(ref Result);

            Result[0, 0] = K1;
            Result[1, 1] = K2;
            Result[2, 2] = K3;

            return (Result);
        }


        //----------------
        //----------------
        //procedure TAffine.Copy(const Src: TAffine);
        //var
        //  I, J: Integer;
        //begin
        //  for I := 0 to 3 do
        //      for J := 0 to 3 do
        //          EL[I, J] := Src.EL[I, J];
        //end;

        public void Copy(TAffine Src)
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
        //procedure TAffine.Clear;
        //begin
        //  ClearElement(EL);
        //end;

        public void Clear()
        {
            ClearElement(ref this.EL);
        }


        //----------------
        //----------------
        //procedure TAffine.Init;
        //begin
        //  InitElement(EL);
        //end;

        public void Init()
        {
            InitElement(ref this.EL);
        }


        //----------------
        // 変換
        //----------------
        //function TAffine.Trans(const PT: TVector): TVector;
        //begin
        //  Result.X := PT.X* EL[0, 0] + PT.Y* EL[1, 0] + PT.Z* EL[2, 0] + 1 * EL[3, 0];
        //  Result.Y := PT.X* EL[0, 1] + PT.Y* EL[1, 1] + PT.Z* EL[2, 1] + 1 * EL[3, 1];
        //  Result.Z := PT.X* EL[0, 2] + PT.Y* EL[1, 2] + PT.Z* EL[2, 2] + 1 * EL[3, 2];
        //end;

        public TVector Trans(TVector PT)
        {
            TVector Result = new TVector
            {
                X = PT.X * this.EL[0, 0] + PT.Y * this.EL[1, 0] + PT.Z * this.EL[2, 0] + 1 * this.EL[3, 0],
                Y = PT.X * this.EL[0, 1] + PT.Y * this.EL[1, 1] + PT.Z * this.EL[2, 1] + 1 * this.EL[3, 1],
                Z = PT.X * this.EL[0, 2] + PT.Y * this.EL[1, 2] + PT.Z * this.EL[2, 2] + 1 * this.EL[3, 2]
            };

            return (Result);
        }


        //----------------
        // 変換追加
        //----------------
        //{
        //   Self M
        // |..J..||.    |
        // |.    ||.    |
        // |I    ||K    |
        // |.    ||.    |
        //}
        //procedure TAffine.Mul(const TM: TAffine);
        //begin
        //  Mul(TM.EL);
        //end;

        public void Mul(TAffine TM)
        {
            Mul(TM.EL);
        }



        //----------------
        //----------------
        //procedure TAffine.Mul(const TE: TAffineElement);
        //var
        //  T: array[0..3] of Double;
        //  I, J, K: Integer;
        //begin
        //  for I := 0 to 3 do
        //  begin
        //      for J := 0 to 3 do
        //      begin
        //          T[J] := 0;
        //          for K := 0 to 3 do
        //              T[J] := T[J] + EL[I, K] * TE[K, J];
        //      end;
        //
        //      for K := 0 to 3 do
        //          EL[I, K] := T[K];
        //  end;
        //end;

        public void Mul(TAffineElement[,] TE)
        {
            double[] T = new double[TE.GetLength(1)];
            int I, J, K;

            for (I = 0; I < TE.GetLength(0); I++)
            {
                for (J = 0; J < TE.GetLength(1); J++)
                {
                    T[J] = 0;

                    for (K = 0; K < this.EL.GetLength(1); K++)
                    {
                        T[J] = T[J] + EL[I, K] * TE[K, J];
                    }
                }

                for (K = 0; K < EL.GetLength(1); K++)
                {
                    EL[I, K] = T[K];
                }
            }
        }


        //----------------
        // 前に変換追加
        //----------------
        //{
        //    M Self
        // |.    ||..J..|
        // |.    ||.    |
        // |K    ||I    |
        // |.    ||.    |
        //}
        //procedure TAffine.MulBefore(const TM: TAffine);
        //begin
        //  MulBefore(TM.EL);
        //end;

        public void MulBefore(TAffine TM)
        {
            MulBefore(TM.EL);
        }



        //----------------
        //----------------
        //procedure TAffine.MulBefore(const TE: TAffineElement);
        //var
        //  A: TAffine;
        //begin
        //  A := TAffine.Create;
        //  try
        //      A.EL := TE;
        //      A.Mul(Self);
        //      EL := A.EL;
        //  finally
        //      A.Free;
        //  end;
        //end;

        public void MulBefore(TAffineElement[,] TE)
        {
            TAffine A;

            A = new TAffine();

            try
            {
                A.EL = TE;
                A.Mul(this);
                EL = A.EL;
            }
            finally
            {
                A = null;
                GC.Collect();
                //A.Free
            }
        }


        //----------------
        // 平行移動追加
        //----------------
        //procedure TAffine.Move(DX, DY, DZ: Double);
        //begin
        //  Mul(MoveElement(DX, DY, DZ));
        //end;
        public void Move(double DX, double DY, double DZ)
        {
            Mul(MoveElement(DX, DY, DZ));
        }


        //----------------
        //----------------
        //procedure TAffine.MoveBefore(DX, DY, DZ: Double);
        //begin
        //  MulBefore(MoveElement(DX, DY, DZ));
        //end;

        public void MoveBefore(double DX, double DY, double DZ)
        {
            MulBefore(MoveElement(DX, DY, DZ));
        }


        //----------------
        // 回転変換追加
        //----------------
        //procedure TAffine.RotateX(Rad: Double);
        //begin
        //  Rotate(1, 0, 0, Rad);
        //end;
        public void RotateX(double Rad)
        {
            Rotate(1, 0, 0, Rad);
        }



        //----------------
        //----------------
        //procedure TAffine.RotateXBefore(Rad: Double);
        //begin
        //  RotateBefore(1, 0, 0, Rad);
        //end;

        public void RotateXBefore(double Rad)
        {
            RotateBefore(1, 0, 0, Rad);
        }


        //----------------
        //----------------
        //procedure TAffine.RotateY(Rad: Double);
        //begin
        //  Rotate(0, 1, 0, Rad);
        //end;

        public void RotateY(double Rad)
        {
            Rotate(0, 1, 0, Rad);
        }


        //----------------
        //----------------
        //procedure TAffine.RotateYBefore(Rad: Double);
        //begin
        //  RotateBefore(0, 1, 0, Rad);
        //end;

        public void RotateYBefore(double Rad)
        {
            RotateBefore(0, 1, 0, Rad);
        }

        //----------------
        //----------------
        //procedure TAffine.RotateZ(Rad: Double);
        //begin
        //  Rotate(0, 0, 1, Rad);
        //end;

        public void RotateZ(double Rad)
        {
            Rotate(0, 0, 1, Rad);
        }


        //----------------
        //----------------
        //procedure TAffine.RotateZBefore(Rad: Double);
        //begin
        //  RotateBefore(0, 0, 1, Rad);
        //end;

        public void RotateZBefore(double Rad)
        {
            RotateBefore(0, 0, 1, Rad);
        }


        //----------------
        //----------------
        //procedure TAffine.Rotate(U1, U2, U3: Double; Rad: Double);
        //begin
        //  Mul(RotateElement(U1, U2, U3, Rad));
        //end;

        public void Rotate(double U1, double U2, double U3, double Rad)
        {
            Mul(RotateElement(U1, U2, U3, Rad));
        }


        //----------------
        //----------------
        //procedure TAffine.RotateBefore(U1, U2, U3: Double; Rad: Double);
        //begin
        //  MulBefore(RotateElement(U1, U2, U3, Rad));
        //end;

        public void RotateBefore(double U1, double U2, double U3, double Rad)
        {
            MulBefore(RotateElement(U1, U2, U3, Rad));
        }


        //----------------
        //----------------
        //procedure TAffine.Tilt(XRad, YRad: Double);
        // Z軸のX,Y方向への倒れ方向
        //      →XRad(>0)
        //     | /
        //     |/
        // ----+---->X
        //var
        //  DX, DY, DXY: Double;
        //begin
        //  DX := Tan(XRad);
        //  DY:= Tan(YRad);
        //  DXY:= Sqrt(Sqr(DX) + Sqr(DY));
        //  if (DXY <> 0) then
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
        //----------------
        //procedure TAffine.TiltBefore(XRad, YRad: Double);
        //var
        //  DX, DY, DXY: Double;
        //begin
        //  DX := Tan(XRad);
        //  DY:= Tan(YRad);
        //  DXY:= Sqrt(Sqr(DX) + Sqr(DY));
        //  if (DXY <> 0) then
        //      RotateBefore(-DY / DXY, DX / DXY, 0, ArcTan(DXY));
        //end;

        public void TiltBefore(double XRad, double YRad)
        {
            double DX, DY, DXY;

            DX = Math.Tan(XRad);
            DY = Math.Tan(YRad);
            DXY = Math.Sqrt(Math.Pow(DX, 2) + Math.Pow(DY, 2));

            if (DXY != 0)
            {
                RotateBefore(-DY / DXY, DX / DXY, 0, Math.Atan(DXY));
            }
        }

        //----------------
        //----------------
        //procedure TAffine.Scale(K1, K2, K3: Double);
        //begin
        //  Mul(ScaleElement(K1, K2, K3));
        //end;

        public void Scale(double K1, double K2, double K3)
        {
            Mul(ScaleElement(K1, K2, K3));
        }


        //----------------
        //----------------
        //procedure TAffine.ScaleBefore(K1, K2, K3: Double);
        //begin
        //  MulBefore(ScaleElement(K1, K2, K3));
        //end;

        public void ScaleBefore(double K1, double K2, double K3)
        {
            MulBefore(ScaleElement(K1, K2, K3));
        }


        //----------------
        //----------------
        //procedure TAffine.Scale(K: Double);
        //begin
        //  Scale(K, K, K);
        //end;

        public void Scale(double K)
        {
            Scale(K, K, K);
        }


        //----------------
        //----------------
        //procedure TAffine.ScaleBefore(K: Double);
        //begin
        //  ScaleBefore(K, K, K);
        //end;

        public void ScaleBefore(double K)
        {
            ScaleBefore(K, K, K);
        }

        //----------------
        //----------------
        //procedure TAffine.Inverse;
        //const
        //  N = 4;
        //  M = 4;
        //var
        //  Inv: TAffine;
        //  LSQ: TLeastSquare;
        //procedure CalcColumn(Index: Integer);
        //var
        //  I: Integer;
        //begin
        //  for I := 0 to N - 1 do
        //  begin
        //      LSQ.SetALine(I, EL[I]);
        //      if (I = Index) then
        //          LSQ.B[I] := 1
        //      else
        //          LSQ.B[I] := 0;
        //  end;
        //
        //  LSQ.Process;
        //  for I := 0 to M - 1 do
        //      Inv.EL[I, Index] := LSQ.X[I];
        //end;
        //var
        //  J: Integer;
        //begin
        //  LSQ := TLeastSquare.Create(N, M);
        //  Inv:= TAffine.Create;
        //  try
        //      for J := 0 to M - 1 do
        //          CalcColumn(J);
        //      Copy(Inv);
        //  finally
        //      Inv.Free;
        //      LSQ.Free;
        //  end;
        //end;

        const int N = 4;
        const int M = 4;

        void CalcColumn(int Index, ref TLeastSquare LSQ, ref TAffine Inv)
        {
            int I;

            double[] tmp = new double[4];

            for (I = 0; I < N; I++)
            {
                tmp[0] = this.EL[I, 0];
                tmp[1] = this.EL[I, 1];
                tmp[2] = this.EL[I, 2];
                tmp[3] = this.EL[I, 3];

                //Array.Copy(this.EL, I, tmp, 0, tmp.GetLength(0));
                LSQ.SetALine(I, tmp);

                if (I == Index)
                {
                    LSQ.B[I] = 1;
                }
                else
                {
                    LSQ.B[I] = 0;
                }
            }

            LSQ.Process(N, M);

            for (I = 0; I < M; I++)
            {
                Inv.EL[I, Index] = LSQ.X[I];
            }
        }

        public void Inverse()
        {
            int I, J;

            TLeastSquare LSQ = new TLeastSquare();
            TAffine Inv = new TAffine();

            //LSQ = LSQ.Create(N, M);
            //Inv = TAffine.Create();
            LSQ.Create(N, M);

            try
            {
                for (J = 0; J < M; J++)
                {
                    CalcColumn(J,ref LSQ, ref Inv);
                }

                Copy(Inv);
            }
            finally
            {
                GC.Collect();
                //Inv.Free;
                //LSQ.Free;
            }
        }



        //----------------
        //----------------
        //procedure TAffine.SetX(const Value: Double);
        //begin
        //  EL[3, 0] := Value;
        //end;

        void SetX(double Value)
        {
            this.EL[3, 0] = Value;
        }

        //----------------
        //----------------
        //procedure TAffine.SetY(const Value: Double);
        //begin
        //  EL[3, 1] := Value;
        //end;

        void SetY(double Value)
        {
            this.EL[3, 1] = Value;
        }


        //----------------
        //----------------
        //procedure TAffine.SetZ(const Value: Double);
        //begin
        //  EL[3, 2] := Value;
        //end;

        void SetZ(double Value)
        {
            this.EL[3, 2] = Value;
        }

        //----------------
        //----------------
        //function TAffine.GetX: Double;
        //begin
        //  Result := EL[3, 0];
        //end;

        double GetX()
        {
            double Result = this.EL[3, 0];

            return (Result);
        }


        //----------------
        //----------------
        //function TAffine.GetY: Double;
        //begin
        //  Result := EL[3, 1];
        //end;

        double GetY()
        {
            double Result = this.EL[3, 1];

            return (Result);
        }


        //----------------
        //----------------
        //function TAffine.GetZ: Double;
        //begin
        //  Result := EL[3, 2];
        //end;

        double GetZ()
        {
            double Result = this.EL[3, 2];

            return (Result);
        }


        //----------------
        //----------------
        //function TAffine.RotX: Double;
        //var
        //  CosB: Double;
        //  X, Y: Double;
        //begin
        //  CosB := Cos(RotY);
        //  X:= EL[2, 2] / CosB;
        //  Y:= -EL[2, 1] / CosB;
        //  if (CosB<> 0) then
        //      if (Sqr(X) + Sqr(Y) < Sqrt(DBL_EPSILON)) then
        //          Result := 0
        //      else
        //          Result:= ArcTan2(Y, X)
        //  else
        //      Result:= 0;
        //end;

        double RotX()
        {
            double Result = 0.0;
            double CosB;
            double X, Y;

            CosB = Math.Cos(RotY());
            X = EL[2, 2] / CosB;
            Y = -EL[2, 1] / CosB;

            if (CosB != 0)
            {
                if (Math.Pow(X, 2) + Math.Pow(Y, 2) < Math.Sqrt(DBL_EPSILON))
                {
                    Result = 0.0;
                }
                else
                {
                    Result = Math.Atan2(Y, X);
                }
            }
            else
            {
                Result = 0.0;
            }

            return (Result);
        }


        //----------------
        //----------------
        //function CustomArcSin(X: Double): Double;
        //begin
        //  X := Max(-1, Min(X, 1));
        //  Result:= ArcSin(X);
        //end;

        double CustomArcSin(double X)
        {
            double Result = 0.0;
            X = Math.Max(-1, Math.Min(X, 1));
            Result = Math.Asin(X);

            return (Result);
        }


        //----------------
        //----------------
        //function TAffine.RotY: Double;
        //begin
        //  Result := CustomArcSin(EL[2, 0]);
        //end;

        double RotY()
        {
            double Result = CustomArcSin(this.EL[2, 0]);

            return (Result);
        }


        //----------------
        //----------------
        //function TAffine.RotZ: Double;
        //var
        //  CosB: Double;
        //  X, Y: Double;
        //begin
        //  CosB := Cos(RotY);
        //  X:= EL[0, 0] / CosB;
        //  Y:= -EL[1, 0] / CosB;
        //  if (CosB<> 0) then
        //      if (Sqr(X) + Sqr(Y) < Sqrt(DBL_EPSILON)) then
        //          Result := 0
        //      else
        //          Result:= ArcTan2(Y, X)
        //  else
        //      Result:= CustomArcSin(EL[1, 0]);
        //end;

        double RotZ()
        {
            double Result = 0.0;
            double CosB;
            double X, Y;

            CosB = Math.Cos(RotY());
            X = EL[0, 0] / CosB;
            Y = -EL[1, 0] / CosB;

            if (CosB != 0)
            {
                if (Math.Pow(X, 2) + Math.Pow(Y, 2) < Math.Sqrt(DBL_EPSILON))
                {
                    Result = 0;
                }
                else
                {
                    Result = Math.Atan2(Y, X);
                }
            }
            else
            {
                Result = CustomArcSin(EL[1, 0]);
            }

            return (Result);
        }


        //----------------
        //----------------
        //procedure TAffine.Add(AP: TAffineParam);
        //begin
        //  RotateZ(AP.RotZ);
        //  RotateY(AP.RotY);
        //  RotateX(AP.RotX);
        //  Move(AP.X, AP.Y, AP.Z);
        //end;

        void Add(TAffineParam AP)
        {
            RotateZ(AP.RotZ);
            RotateY(AP.RotY);
            RotateX(AP.RotX);
            Move(AP.X, AP.Y, AP.Z);
        }


        //----------------
        //----------------
        //procedure TAffine.AddBefore(AP: TAffineParam);
        //begin
        //  MoveBefore(AP.X, AP.Y, AP.Z);
        //  RotateXBefore(AP.RotX);
        //  RotateYBefore(AP.RotY);
        //  RotateZBefore(AP.RotZ);
        //end;

        void AddBefore(TAffineParam AP)
        {
            MoveBefore(AP.X, AP.Y, AP.Z);
            RotateXBefore(AP.RotX);
            RotateYBefore(AP.RotY);
            RotateZBefore(AP.RotZ);
        }


        //----------------
        //----------------
        //procedure TAffine.Delete(AP: TAffineParam);
        //begin
        //  Move(-AP.X, -AP.Y, -AP.Z);
        //  RotateX(-AP.RotX);
        //  RotateY(-AP.RotY);
        //  RotateZ(-AP.RotZ);
        //end;

        void Delete(TAffineParam AP)
        {
            Move(-AP.X, -AP.Y, -AP.Z);
            RotateX(-AP.RotX);
            RotateY(-AP.RotY);
            RotateZ(-AP.RotZ);
        }


        //----------------
        //----------------
        //procedure TAffine.DeleteBefore(AP: TAffineParam);
        //begin
        //  RotateZBefore(-AP.RotZ);
        //  RotateYBefore(-AP.RotY);
        //  RotateXBefore(-AP.RotX);
        //  MoveBefore(-AP.X, -AP.Y, -AP.Z);
        //end;

        void DeleteBefore(TAffineParam AP)
        {
            RotateZBefore(-AP.RotZ);
            RotateYBefore(-AP.RotY);
            RotateXBefore(-AP.RotX);
            MoveBefore(-AP.X, -AP.Y, -AP.Z);
        }


        //----------------
        //----------------
        //procedure TAffine.SetParam(const Value: TAffineParam);
        //begin
        //  Init;
        //  Add(Value);
        //end;

        void SetParam(TAffineParam Value)
        {
            Init();
            Add(Value);
        }

        //----------------
        //----------------
        //function TAffine.GetParam: TAffineParam;
        //begin
        //  Result.X := X;
        //  Result.Y := Y;
        //  Result.Z := Z;
        //  Result.RotX := RotX;
        //  Result.RotY := RotY;
        //  Result.RotZ := RotZ;
        //end;

        TAffineParam GetParam()
        {
            TAffineParam Result = new TAffineParam
            {
                X = X,
                Y = Y,
                Z = Z,
                RotX = RotX(),
                RotY = RotY(),
                RotZ = RotZ()
            };

            return (Result);
        }


        //----------------
        //----------------
        //constructor TAffine.Create;
        //begin
        //  inherited;
        //  Init;
        //end;

        void Create()
        {
            //inherited;
            Init();
        }


        //----------------
        //----------------
        //function TAffine.ScaleX: Double;
        //begin
        //  Result := EL[0, 0];
        //end;

        double ScaleX()
        {
            double Result= this.EL[0, 0];

            return (Result);
        }


        //----------------
        //----------------
        //function TAffine.ScaleY: Double;
        //begin
        //  Result := EL[1, 1];
        //end;

        double ScaleY()
        {
            double Result = this.EL[1, 1];

            return (Result);
        }


        //----------------
        //----------------
        //function TAffine.ScaleZ: Double;
        //begin
        //  Result := EL[2, 2];
        //end;

        double ScaleZ()
        {
            double Result = this.EL[2, 2];

            return (Result);
        }
    
    }
}
