/*
if �� else �̑Ή��֌W

{} �ł�����Ȃ��ꍇ�A
else �͈�ԋ߂� if �ɑΉ��B

if(a)
if(b) y();
else z();

�Ȃ�A

if(a)
{
	if(b)
		y();
	else
		z();
}
 */

#include<stdio.h>

int main()
{
	if (0)
	if (0)
		puts("1");
	else if (0)
	if (1)
		puts("2");
	else
		puts("3");
	else
		puts("4");
	else 
		puts("5");
	/* ��
	 * 1�`5�A�ǂꂪ�\�������ł��傤�H
	 */

	if (0)
	{
		if (0)
		{
			puts("1");
		}
		else if (0)
		{
			if (1)
				puts("2");
			else
				puts("3");
		}
		else
			puts("4");
	}
	else
		puts("5");
	/* ��
	 * �C���f���g����΁A�ǂꂪ���s����邩�͂����Ԗ��āB
	 * �C���f���g�͂�������ƁB
	 */

	return 0;
}

/*
�E���K
if() ���� 0, 1 �����낢��ς��Ď��s���Ă݂�B
 */
