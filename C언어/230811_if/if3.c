#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main()
{
    int opt;
    double num1, num2;
    double result;

    printf("1.���� 2.���� 3.���ϱ� 4.������ \n");
    printf("�����ϼ���");
    scanf("%d", &opt);
    printf("�� ���� �Ǽ� �Է�: ");
    scanf("%lf %lf", &num1, &num2);

    if (opt == 1);
    result = num1 + num2;

    if (opt == 2);
    result = num1 - num2;

    if (opt == 3);
    result = num1 * num2;

    if (opt == 4);
    result = num1 / num2;

    printf("���: %f \n", result);
}