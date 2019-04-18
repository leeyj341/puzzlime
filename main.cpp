#include <stdio.h>

int LSearch(int ar[], int len, int target)
{
	int i = 0;
	for (i = 0; i < len; i++)
	{
		if (ar[i] == target)
			return i; // ã�� ����� �ε��� �� ��ȯ
	}
	return -1; // ã�� ����
}

int BSearch(int ar[], int len, int target)
{
	int first = 0;
	int last = len - 1;
	int mid;
	int opCount = 0;			// �񱳿����� Ƚ���� ���

	while (first <= last)
	{
		mid = (first + last) / 2;

		if (target == ar[mid])
		{
			return mid;
		}
		else
		{
			if (target < ar[mid])
				last = mid - 1; // 1�� ���ִ� ������ ���� �񱳸� �� �� ���� �ʱ� ���ؼ�
								// while�� ���ǿ� ���� ���ѷ����� �� �� ����.
			else
				first = mid + 1; // ��������
		}
		opCount += 1;
	}
	printf("�� ���� Ƚ��: %d \n", opCount); // while���� ���������� ���ϱ� ���нÿ��� ��µ�
	return -1;
}

int main(void)
{
	/*int arr[] = { 3,5,2,4,9 };
	int idx;
	
	idx = LSearch(arr, sizeof(arr) / sizeof(int), 4);
	if (idx == -1)
		printf("Ž�� ���� \n");
	else
		printf("Ÿ�� ���� �ε���: %d \n", idx);
	
	idx = LSearch(arr, sizeof(arr) / sizeof(int), 7);
	if (idx == -1)
		printf("Ž�� ���� \n");
	else
		printf("Ÿ�� ���� �ε���: %d \n", idx);*/

	/*int arr[] = { 1,3,5,7,9 };
	int idx;

	idx = BSearch(arr, sizeof(arr) / sizeof(int), 7);

	if (idx == -1)
		printf("Ž�� ���� \n");
	else
		printf("Ÿ�� ���� �ε���: %d \n", idx);

	idx = BSearch(arr, sizeof(arr) / sizeof(int), 4);

	if (idx == -1)
		printf("Ž�� ���� \n");
	else
		printf("Ÿ�� ���� �ε���: %d \n", idx);*/

	int arr1[500] = { 0, };
	int arr2[5000] = { 0, };
	int arr3[50000] = { 0, };
	int idx;

	//�迭 arr1�� �������, ������� ���� ���� 1�� ã����� ���
	idx = BSearch(arr1, sizeof(arr1) / sizeof(int), 1);
	if (idx == -1)
		printf("Ž�� ���� \n\n");
	else
		printf("Ÿ�� ���� �ε��� : %d \n", idx);

	idx = BSearch(arr2, sizeof(arr2) / sizeof(int), 1);
	if (idx == -1)
		printf("Ž�� ���� \n\n");
	else
		printf("Ÿ�� ���� �ε��� : %d \n", idx);

	idx = BSearch(arr3, sizeof(arr3) / sizeof(int), 1);
	if (idx == -1)
		printf("Ž�� ���� \n\n");
	else
		printf("Ÿ�� ���� �ε��� : %d \n", idx);


	//��ǿ�ģ�� ���Ϳ���
	//�ʹ��Ϳ���
	//�ʹ��ʹ��Ϳ���
	
	return 0;
}