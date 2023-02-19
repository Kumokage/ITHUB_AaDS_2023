namespace Lesson3;

public static class Sorting
{
    public static void Bubble(ref int[] arr)
    {
        for (int k = arr.Length; k > 0; --k)
        {
            for (int i = 0; i < k; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    int temp = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = temp;
                }
            }
        }
    }

    public static void SelectSort(ref int[] arr)
    {
        int max;
        for (int k = 0; k < arr.Length; k++)
        {
            // find index min 
            max = 0;
            for (int i = 1; i < arr.Length - k; i++)
            {
                if (arr[i] > arr[max])
                    max = i;
            }

            // swap
            int temp = arr[arr.Length - k - 1];
            arr[arr.Length - k - 1] = arr[max];
            arr[max] = temp;
        }
    }

    private static void MergeSort(ref int[] arr, ref int[] buf, int l, int r) {
        if (l >= r)
            return;

        
        int m = (l + r) / 2;
        MergeSort(ref arr, ref buf, l, m);
        MergeSort(ref arr, ref buf, m + 1, r);

        // Merge
        int k = l;
        for (int i = l, j = m + 1; i <= m || j <= r; ) {
            if (j > r || (i <= m && arr[i] < arr[j])) {
                buf[k] = arr[i];
                ++i;
            }
            else {
                buf[k] = arr[j];
                ++j;
            }
            ++k;
        }
        for (int i = l; i <= r; ++i) {
            arr[i] = buf[i];
        }
        
    }

    public static void MergeSort(ref int[] arr) {
        if (arr.Length == 0)
            return;

        int[] buf = new int[arr.Length];
        MergeSort(ref arr, ref buf, 0, arr.Length - 1);
    }

    private static void QuickSort(ref int[] arr, int l, int r) {
        if (l < r) {
            // Индекс где должен находится опорный элемент
            int q = r;

            // Значение опорного элемента
            int x = arr[l];

            for(int i = l + 1; i <= q;) {
                if (arr[i] > x) {
                    // swap i and q
                    int buf_1 = arr[i];
                    arr[i] = arr[q];
                    arr[q] = buf_1;
                    --q;
                }
                else {
                    ++i;
                }
            }

            int buf = arr[q];
            arr[q] = arr[l];
            arr[l] = buf;

            QuickSort(ref arr, l, q - 1);
            QuickSort(ref arr, q + 1, r);
        }
    }

    public static void QuickSort(ref int[] arr) {

    }

}