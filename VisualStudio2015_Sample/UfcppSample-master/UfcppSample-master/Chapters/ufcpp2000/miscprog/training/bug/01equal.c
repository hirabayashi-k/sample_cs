/*
= �� ==
 */

#include<stdio.h>

#define ACTIVE 0
#define DONE 1

int SomeAction()
{
	printf("some action\n");
	return DONE;
}

int main()
{
	int flag = ACTIVE;

	while(flag == ACTIVE)
	{
		flag = SomeAction();
	}

	return 0;
}

/*
�E���K1
16�s�ځA == �� = �ƊԈႤ�ƁE�E�E
�����Ă݂悤�B

���Ȃ݂ɁA-Wall �I�v�V�����Ƃ���t���Čx�����x�����グ��Ɠ{����͂��B
while �Ƃ� if �� () �̒��ɑ�����𒼐ڏ����Ȃ��āB

�E���K2
����ɁAACTIVE �� DONE �̒l�� 0, 1 �t�ɂ�����ǂ��Ȃ邩�������Ă݂悤�B

�v���O�����̋����I���� ctrl + C�B
 */
