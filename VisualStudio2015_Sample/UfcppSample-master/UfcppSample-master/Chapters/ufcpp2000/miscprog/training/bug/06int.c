/*
int, double�A�Öق̌^�ϊ�

int �� double �̈Öق̌^�ϊ��ɋC�����܂��傤�B

����Z�̎��ɂ� int �̊���Z�� double �̊���Z�̈Ⴂ�ɋC�����܂��傤�B
 */

#include<stdio.h>
#include<math.h>

int main()
{
	int x;
	double y;

	x = atan(1) * 4;
	printf("%f\n", sin(x));
	/* ��
	 * x �̒l�� �� �ɂȂ�������ł���ƁE�E�E
	 * 
	 * double �� int �͏���ɕϊ�����Ă��܂��B
	 * �R���p�C���ɂ���ẮAdouble �� int �̕ϊ����Öقɂ��悤�Ƃ���ƌx�����������̂��B
	 * gcc �̏ꍇ�A-Wall �I�v�V����������Όx�����o���Ă��炦��B
	 */

	y = 11 / 10;
	printf("%f\n", y);
	/* ��
	 * �Öق̌^�ϊ�������̂͑�����̂݁B
	 * 11 �� 10 �� int �Ȃ̂ŁE�E�E
	 * 
	 * y == 1.1 �ɂ�������΁A�ȉ��̂悤�ɂ���B
	 * y = (double)11 / 10;
	 * �܂���
	 * y = 11.0 / 10.0;
	 * 
	 * ���R�A�ȉ��̂悤�Ȃ̂ł͑ʖځB
	 * y = (double)(11 / 10);
	 */

	return 0;
}

/*
�E���K
x �� double �ɂ��Ă݂܂��傤�B
�܂��Ay �̒l�������� 1.1 �ɂȂ�悤�ɏC�����܂��傤�B
 */
