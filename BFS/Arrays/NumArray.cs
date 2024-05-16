namespace Interview.Samples.Application.Arrays
{
    /// <summary>
    /// https://leetcode.com/problems/range-sum-query-immutable
    /// </summary>
    public class NumArray
    {
        private readonly int[] prefixSum;

        public NumArray(int[] array)
        {
            prefixSum = new int[array.Length + 1];

            prefixSum[0] = array[1] + array[0];
            for (int i = 0; i < array.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + array[i];
            }
        }

        public int SumRange(int left, int rigth)
        {
            var sum = prefixSum[rigth +1] - prefixSum[left];
            
            return sum;
        }
    }
}
