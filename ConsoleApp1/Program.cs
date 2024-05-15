using System;

class Program
{
    static void Main()
    {
        int[] arr = { 3, 0, 2, 5, -1, 4, 1 };

        // Лямбда-выражение, определяющее порядок сортировки
        // по возрастанию: (x, y) => x < y
        // по убыванию: (x, y) => x > y
        HeapSort(arr, (x, y) => x < y);

        Console.WriteLine(string.Join(", ", arr));
    }

    static void HeapSort(int[] arr, Func<int, int, bool> order)
    {
        // Построение кучи (перегруппируем массив)
        for (int i = arr.Length / 2 - 1; i >= 0; i--)
            Heapify(arr, arr.Length, i, order);

        // Один за другим извлекаем элементы из кучи
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            // Перемещаем текущий корень в конец
            (arr[0], arr[i]) = (arr[i], arr[0]);

            // вызываем процедуру heapify на уменьшенной куче
            Heapify(arr, i, 0, order);
        }
    }

    static void Heapify(int[] arr, int n, int i, Func<int, int, bool> order)
    {
        int largest = i; // Инициализируем наибольший элемент как корень
        int l = 2 * i + 1; // левый = 2*i + 1
        int r = 2 * i + 2; // правый = 2*i + 2

        // Если левый дочерний элемент больше корня
        if (l < n && order(arr[largest], arr[l]))
        {
            largest = l;
        }

        // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
        if (r < n && order(arr[largest], arr[r]))
        {
            largest = r;
        }

        // Если самый большой элемент не корень
        if (largest != i)
        {
            (arr[i], arr[largest]) = (arr[largest], arr[i]); // поменять местами

            // Рекурсивно преобразуем затронутую подкучу
            Heapify(arr, n, largest, order);
        }
    }
}


/*using System;

class कार्यक्रम
{
    static void मुख्य()
    {
        int[] संख्या_सरणी = { 3, 0, 2, 5, -1, 4, 1 };

        हीप_सॉर्ट(संख्या_सरणी, (x, y) => x < y);

        Console.WriteLine(string.Join(", ", संख्या_सरणी));
    }

    static void हीप_सॉर्ट(int[] संख्या_सरणी, Func<int, int, bool> क्रम)
    {
        for (int i = संख्या_सरणी.Length / 2 - 1; i >= 0; i--)
            हीपिफ़ाय(संख्या_सरणी, संख्या_सरणी.Length, i, क्रम);

        for (int i = संख्या_सरणी.Length - 1; i >= 0; i--)
        {
            (संख्या_सरणी[0], संख्या_सरणी[i]) = (संख्या_सरणी[i], संख्या_सरणी[0]);
            हीपिफ़ाय(संख्या_सरणी, i, 0, क्रम);
        }
    }

    static void हीपिफ़ाय(int[] संख्या_सरणी, int n, int i, Func<int, int, bool> क्रम)
    {
        int सबसे_बड़ा = i;
        int बायां = 2 * i + 1;
        int दायां = 2 * i + 2;

        if (बायां < n && क्रम(संख्या_सरणी[सबसे_बड़ा], संख्या_सरणी[बायां]))
        {
            सबसे_बड़ा = बायां;
        }

        if (दायां < n && क्रम(संख्या_सरणी[सबसे_बड़ा], संख्या_सरणी[दायां]))
        {
            सबसे_बड़ा = दायां;
        }

        if (सबसे_बड़ा != i)
        {
            (संख्या_सरणी[i], संख्या_सरणी[सबसे_बड़ा]) = (संख्या_सरणी[सबसे_बड़ा], संख्या_सरणी[i]);
            हीपिफ़ाय(संख्या_सरणी, n, सबसे_बड़ा, क्रम);
        }
    }
}*/