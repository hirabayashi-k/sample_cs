/*
���l�͈̔�
 */

#include<stdio.h>
#include<math.h>

int main()
{
	char i;
	unsigned int j;

	for (i = 0; i < 300; ++i)
	{
		printf("%d", i);
	}
	/* ��
	 * i �� char �^�Ȏ���Y��Ă���ƁE�E�E
	 * 
	 * char �� 0�`255 �������� -128�`127 �Ȃ̂ŁA300 �͐�Β����Ȃ��B
	 * 
	 * 0�`255 �̏ꍇ�A255 + 1 �� 0 �����A
	 * -128�`127 �̏ꍇ�A127 + 1 �� -128�B
	 * ���Ȃ݂ɁAchar �������t�ɂȂ邩�����Ȃ��ɂȂ邩�͏����n�ˑ��B
	 * 
	 * �v���O�����̋����I���� ctrl + C �ŁB
	 */

	for (j = 30; j >= 0; --j)
	{
		printf("%d", j);
	}
	/* ��
	 * j �� �����Ȃ��Ȏ���Y��Ă���ƁE�E�E
	 * 
	 * unsigned �̏ꍇ�A0 - 1 �� UINT_MAX�iunsigend int �̍ő�l�j�ɂȂ�B
	 * j >= 0 �͏�ɐ^�B
	 * 
	 * �v���O�����̋����I���� ctrl + C �ŁB
	 */

	return 0;
}

/*
�E���K
i, j �� int �ɕς��Ă݂܂��傤�B
 */
