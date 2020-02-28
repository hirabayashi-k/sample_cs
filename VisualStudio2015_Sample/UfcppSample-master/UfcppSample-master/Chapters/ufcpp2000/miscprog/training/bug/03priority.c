/*
演算子の優先順位

*, / と +, - の優先順位を間違える人はいないと思うけど・・・
迷うくらいなら () でくくるように。
 */

#include<stdio.h>

int main()
{
	printf("%d\n", 1 << 3 + 1);
	/* ↑
	 * (1 << 3) + 1 → 9 ？
	 * 1 << (3 + 1) → 16？
	 * 
	 * 8倍（* 8）のつもりで << 3 とする時には注意。
	 */

#define MASK 0xff

	printf("%d\n", 0x9999 & MASK == 0x99);
	/* ↑
	 * この & は「ビットごとの AND」。
	 * マスクを掛けて、下位1バイトを取り出す。
	 * 
	 * (0x9999 & MASK) == 0x99 → 0x99 == 0x99 → 1 (true) ？
	 * 0x9999 & (MASK == 0x99) → 0x9999 & 0 → 0 ？
	 */

	printf("%d\n", 2 & 3 | 5);
	/* ↑
	 * 2 & (3 | 5) → 2 & 7 → 2 ？
	 * (2 & 3) | 5 → 2 | 5 → 7 ？
	 * 
	 * まあ、これは、
	 * & が論理“積”、| が論理“和”といわれることから、
	 * どっちが優先されるか分かるかもしれないけども。
	 * + と * 程は分かりやすくないんで、() を付けること推奨。
	 */

	return 0;
}

/*
ちなみに、こういう優先順位の不明瞭な式も、
-Wall オプションとかを付けて警告レベルを上げると怒られるはず。

・演習
() の位置を付け替えて、結果がどう変わるか確かめよう。
 */
