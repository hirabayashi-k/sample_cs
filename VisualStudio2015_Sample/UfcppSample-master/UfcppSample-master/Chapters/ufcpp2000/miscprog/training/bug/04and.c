/*
&& �� ||

&& �� || �͂�����Ɠ���ȉ��Z�q�B
 */

#include<stdio.h>

int foo(int flag)
{
	puts("foo");
	return flag;
}

int bar(int flag)
{
	puts("bar");
	return flag;
}

int main()
{
	printf("%d\n", foo(0) || bar(0));
	printf("%d\n", foo(1) || bar(0));
	printf("%d\n", foo(0) && bar(0));
	printf("%d\n", foo(1) && bar(0));
	/* ��
	 * "bar" ���\�������Ƃ��Ƃ���Ȃ��Ƃ�������͂��B
	 * 
	 * && �c ������ 0 ���ƁA���̎��_�� AND �̌��ʂ� 0 �Ɋm�肷��̂ŁA
	 *       �E���͎��s����Ȃ��B
	 * || �c ����B
	 *       �������� 0 ���ƁA�E���͎��s����Ȃ��B
	 */

	return 0;
}

/*
|| �̐������g���āA

SomeOperation() || exit();
��
�����ASomeOperation �� 0 ��Ԃ��ꍇ�A�v���O�����I���B

�Ƃ����悤�ȃg���b�L�[�ȃR�[�h�������l���B
(C ����ł͂��܂萄������Ȃ��BPerl ���Ƃ悭��������B)

�E���K
||, �� && �� |, & �ɕς��Ă���Ă݂悤�B

���Ȃ݂ɁA||, && �ȊO�̉��Z�q�̏ꍇ�A
���Z�q�̍����ƉE���A�ǂ��炪��Ɏ��s����邩��
C ����̋K�i�㌈�܂��Ă��Ȃ��i�ǂ���ł��K�i�ᔽ�ł͂Ȃ��j�B
 */
