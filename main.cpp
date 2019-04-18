#include <stdio.h>

int LSearch(int ar[], int len, int target)
{
	int i = 0;
	for (i = 0; i < len; i++)
	{
		if (ar[i] == target)
			return i; // 찾은 대상의 인덱스 값 반환
	}
	return -1; // 찾지 못함
}

int BSearch(int ar[], int len, int target)
{
	int first = 0;
	int last = len - 1;
	int mid;
	int opCount = 0;			// 비교연산의 횟수를 기록

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
				last = mid - 1; // 1을 빼주는 이유는 같은 비교를 두 번 하지 않기 위해서
								// while문 조건에 의해 무한루프가 될 수 있음.
			else
				first = mid + 1; // 마찬가지
		}
		opCount += 1;
	}
	printf("비교 연산 횟수: %d \n", opCount); // while문을 빠져나왔을 때니까 실패시에만 출력됨
	return -1;
}

int main(void)
{
	/*int arr[] = { 3,5,2,4,9 };
	int idx;
	
	idx = LSearch(arr, sizeof(arr) / sizeof(int), 4);
	if (idx == -1)
		printf("탐색 실패 \n");
	else
		printf("타겟 저장 인덱스: %d \n", idx);
	
	idx = LSearch(arr, sizeof(arr) / sizeof(int), 7);
	if (idx == -1)
		printf("탐색 실패 \n");
	else
		printf("타겟 저장 인덱스: %d \n", idx);*/

	/*int arr[] = { 1,3,5,7,9 };
	int idx;

	idx = BSearch(arr, sizeof(arr) / sizeof(int), 7);

	if (idx == -1)
		printf("탐색 실패 \n");
	else
		printf("타겟 저장 인덱스: %d \n", idx);

	idx = BSearch(arr, sizeof(arr) / sizeof(int), 4);

	if (idx == -1)
		printf("탐색 실패 \n");
	else
		printf("타겟 저장 인덱스: %d \n", idx);*/

	int arr1[500] = { 0, };
	int arr2[5000] = { 0, };
	int arr3[50000] = { 0, };
	int idx;

	//배열 arr1을 대상으로, 저장되지 않은 정수 1을 찾으라고 명령
	idx = BSearch(arr1, sizeof(arr1) / sizeof(int), 1);
	if (idx == -1)
		printf("탐색 실패 \n\n");
	else
		printf("타겟 저장 인덱스 : %d \n", idx);

	idx = BSearch(arr2, sizeof(arr2) / sizeof(int), 1);
	if (idx == -1)
		printf("탐색 실패 \n\n");
	else
		printf("타겟 저장 인덱스 : %d \n", idx);

	idx = BSearch(arr3, sizeof(arr3) / sizeof(int), 1);
	if (idx == -1)
		printf("탐색 실패 \n\n");
	else
		printf("타겟 저장 인덱스 : %d \n", idx);


	//사실여친이 더귀여워
	//너무귀여웡
	//너무너무귀여웡
	
	return 0;
}