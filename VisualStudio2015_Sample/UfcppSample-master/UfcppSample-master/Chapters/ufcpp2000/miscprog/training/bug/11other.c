/*
���̑����X�A������Ⴂ�����ȃ~�X
 */

#include<stdio.h>

int * FunctionWithPointerValue(int n)
{
	int a = n * n;
	return &a;
	/* ��
	 * ���[�J���ϐ��̃A�h���X��Ԃ��Ă��A
	 * �֐��𔲂������_�Ń��[�J���ϐ��̎������s���ď�����̂ŁA
	 * ���Ғʂ�̌��ʂ͓����Ȃ��B
	 */
}

double BasicLikeArrayAccess(double *x, int i)
{
	return x[i - 1];
	/* ��
	 * BASIC �Ȃ񂩂ł́A�z��C���f�b�N�X�� 1 ����n�܂��ėv�f�� N �ŏI���B
	 * C ����̔z��� 0 �` N-1�B
	 * 
	 * �z��̃C���f�b�N�X�Ɋւ��ẮA�����ɂȂ�Ă��āA
	 * 1 ����n�߂�~�X�Ȃ�Ă��Ȃ��Ȃ�Ǝv�����ǁA
	 * ���̗�݂����ɁA���X�ABASIC ���̃C���f�b�N�X�̎���������֐����������肷��̂Œ��ӁB
	 */
}

void GetInterval(int *points, int n, int *intervals)
{
	int i;
	for (i = 0; i < n - 1; ++i)
	{
		intervals[i] = points[i + 1] - points[i];
	}
	/* ��
	 * for ���� i < n - 1 �ɒ��ӁB
	 * n �v�f�̔z��̍����� n - 1 �v�f�B
	 */
}

void IncreamentAll(int *array, int n)
{
	//while (--n >= 0) ++*(array++);
	/* ��
	 * �z��̑S�v�f�� �{1 ����R�[�h�B
	 * 
	 * 1�s�ł����Ȃ��Ƃ�����Ă��āA�������悳���Ɍ����邯�ǁA
	 * �l�������Ƃ��̂��Ƃ��l���āA�����ƌ��₷���R�[�h���������������B
	 * �ʓ|�ł��A�ȉ��̂悤�ɏ����̂𐄏��B
	 * 

	for (; n >= 0; --n, ++array)
	{
		++(*array);
	}

	 * 
	 * ++ �� -- �����̓r���Ŏg���̂̓~�X�̌����ɂȂ�₷���B
	 * ++a �� a++ �̈Ⴂ�ɂ��C�����Ȃ��Ⴂ���Ȃ��Ȃ邵�B
	 */
}

void DoubleLoop()
{
	while (1) /* �O���[�v */
	{
		while (1) /* �����[�v */
		{
			break;
		}
	}
	/* ��
	 * �i�v���[�v�B
	 * break �ł͓����[�v�����������Ȃ��B
	 * 
	 * ���d���[�v���� break ��������� goto ���g�킴��𓾂Ȃ��B
	 * ����܂胋�[�v���[���Ƃ��̎�̃~�X�������Ȃ�̂ŁA
	 * ���[�v���[���Ȃ肷����悤�Ȃ烋�[�v�̒��g���֐������ׂ��B
	 */
}

#include <stdlib.h>

void FogetFree()
{
#define LARGE_SIZE 1000000

	int i;
	for (i = 0; i<1000000; ++i)
	{
		int *x = malloc(LARGE_SIZE);

		/*
		free(x);
		 */
	}
	/* ��
	 * �����A�r���Ŏ��s���G���[�ɂȂ邩�AOS �����肩����͂��B
	 * malloc �Ŋm�ۂ����������́A�g���I������� free �ŉ�@���Ȃ��ƑʖځB
	 * 
	 * free(x) �̏��̃R�����g���O���΂����烋�[�v���܂킵�Ă������Ȃ��Ȃ�B
	 */
}

void FogetInitialize()
{
	int x, y, z;
	printf("%d, %d, %d\n", x, y, z);
	/* ��
	 * �����������ɒl��ǂ����Ƃ���ƕςȒl�������Ă���B
	 * C ����́A�����Œl�����������Ă��ꂽ��͂��Ȃ��B
	 * 
	 * ���i���炿���Ə���������Ȃ�t���Ēu���悤�ɁB
	 */
}

int main()
{
	return 0;
}

/*
�E���K
main �֐�����e�֐����Ăяo���ē�����m�F���Ă݂悤�B



���̑�:
�E ; �� :�A. �� , �ȂǁA�^�C�v�~�X���₷���̂Œ���
�Escanf("%d", &x) �Ə����ׂ��Ƃ���� scanf("%d",x) �Ə����Ă��܂����Ƃ�����
 */
