/*********************************************************************
fftsg.c �̓��e�� Managed �R�[�h���痘�p���邽�߂̃��b�p�[�B
fftsg.c ���� rdft (���ԗ̈�̎��M�������̎��g������) ���g���Ă��܂��B

[�g�p���@]
�E���t�[���G�ϊ�
Fft::Fft(length);
length: �ϊ����M���̒����B

Fft::Transform(sgn, a);
sgn: �ϊ��̕����B
     1 �ŏ������A-1 �ŋt�����B
a  : �ϊ����̃f�[�^�B

�ϊ��O�̃f�[�^�`���́A
���ԗ̈�̎��M��
a[k] = x[k];
(0 <= k < N)

�ϊ���̃f�[�^�`���́A
a[0]    : ��������       Re(X[0])
a[1]    : �ō����g������ Re(X[N/2])
a[2*i]  : �����̎���     Re(X[i])
a[2*i+1]: �����̋���     Im(X[i])
(0 < i < N/2)

Fft::Transform(1, x);
�̋t�ϊ���
Fft::Transform(-1, x);
for(int i=0; i<N, ++i)
  x[i] *= 2/N;

�E���f�t�[���G�ϊ�
Fft::Fft(length);
length: �ϊ����M���̒����B
        (a �̒��� �� x �̒�����2�{)

CFft::Transform(sgn, x);
sgn: �ϊ��̕����B
     1 �ŏ������A-1 �ŋt�����B
x  : �ϊ����̃f�[�^�B

�ϊ��O�̃f�[�^�`���́A
a[2*i]  : �����̎��� Re(x[k])
a[2*i+1]: �����̋��� Im(x[k])
(0 <= k < N/2)

�ϊ���̃f�[�^�`���́A
a[2*i]  : �����̎��� Re(X[i])
a[2*i+1]: �����̋��� Im(X[i])
(0 < i= < N/2)

CFft::Transform(1, x);
�̋t�ϊ���
CFft::Transform(-1, x);
for(int i=0; i<N, ++i)
  x[i] *= 2/N;

 *********************************************************************/

#using <mscorlib.dll>
using namespace System;

extern "C"
{
	void rdft(int n, int isgn, double *a, int *ip, double *w);
	void cdft(int n, int isgn, double *a, int *ip, double *w);
};

namespace Fft
{
	//==================================================================
	// ���t�[���G�ϊ��N���X�B
	__gc public class Fft
	{
		int length; // FFT �̒���
		double* w; // bit reversal �p���[�N�̈�
		int* ip;   // sin/cos �e�[�u���p���[�N�̈�

	public:
		Fft(int length)
		{
			this->length = length;
			this->ip = new int[(int)(2 + Math::Ceiling(Math::Sqrt(length / 2)))];
			this->ip[0] = 0;
			this->w = new double[length / 2];
		}

		void Transform(int sgn, double* x)
		{
			rdft(this->length, sgn, x, this->ip, this->w);
		}
	};

	//==================================================================
	// ���f�t�[���G�ϊ��N���X�B
	__gc public class CFft
	{
		int length; // FFT �̒���
		double* w; // bit reversal �p���[�N�̈�
		int* ip;   // sin/cos �e�[�u���p���[�N�̈�

	public:
		CFft(int length)
		{
			this->length = length;
			this->ip = new int[(int)(2 + Math::Ceiling(Math::Sqrt(length / 2)))];
			this->ip[0] = 0;
			this->w = new double[length / 2];
		}

		void Transform(int sgn, double* x)
		{
			cdft(this->length, sgn, x, this->ip, this->w);
		}
	};
};
