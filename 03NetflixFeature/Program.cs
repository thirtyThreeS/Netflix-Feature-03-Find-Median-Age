using _03NetflixFeature;

class MedianOfAges
{
    MaxHeap<int> maxHeap;
    MinHeap<int> minHeap;

    public MedianOfAges()
    {
        maxHeap = new MaxHeap<int>();
        minHeap = new MinHeap<int>();
    }

    public void InsertNum(int num)
    {
        if (maxHeap.size() == 0 || maxHeap.peek() >= num) { maxHeap.insert(num); }
        else { minHeap.insert(num); }

        if (maxHeap.size() > minHeap.size() + 1)
        {
            minHeap.insert(maxHeap.peek());
            maxHeap.poll();
        }
        else if (maxHeap.size() < minHeap.size())
        {
            maxHeap.insert(minHeap.peek());
            minHeap.poll();
        }
    }

    public double FindMedian()
    {
        if (maxHeap.size() == minHeap.size()) return maxHeap.peek() / 2.0 + minHeap.peek() / 2.0;
        return maxHeap.peek();
    }

    public static void Main(string[] args)
    {
        MedianOfAges medianOfAges = new();
        medianOfAges.InsertNum(22);
        medianOfAges.InsertNum(35);
        Console.WriteLine("The recommended content will be for ages under: " + medianOfAges.FindMedian());
        medianOfAges.InsertNum(30);
        Console.WriteLine("The recommended content will be for ages under: " + medianOfAges.FindMedian());
        medianOfAges.InsertNum(25);
        Console.WriteLine("The recommended content will be for ages under: " + medianOfAges.FindMedian());
    }
}