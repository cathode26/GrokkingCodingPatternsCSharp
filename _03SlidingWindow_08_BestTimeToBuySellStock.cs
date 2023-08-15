using System;

namespace EducativeGrokkingCodingPatterns
{
    /*
     * Best Time to Buy and Sell Stock
       Given an array where the element at the index i represents the price of a stock on day i, 
       find the maximum profit that you can gain by buying the stock once and then selling it.

       Note: Stock can only be purchased on a single day and sold on a different day. 
             If no profit can be achieved, we return zero.

    */

    class _03SlidingWindow_08_BestTimeToBuySellStock
    {
        public static int MaxProfit(int[] stockPrices)
        {
            // If there are no prices or only one price, there's no profit to be made.
            if (stockPrices.Length <= 1)
                return 0;

            // Initialize variables to store minimum purchase price and maximum profit.
            int buy = 0;
            int sell = 1;
            int maxProfit = stockPrices[sell] - stockPrices[buy];
            // Loop through the prices.
            for (; sell < stockPrices.Length; ++sell)
            {
                // If the current price is less than the minimum purchase price found so far,
                // update the minimum purchase price.
                if (stockPrices[buy] > stockPrices[sell])
                    buy = sell;
                // else calculate potential profit by subtracting the buy price from the sell price.
                else if (stockPrices[sell] - stockPrices[buy] > maxProfit)
                    maxProfit = stockPrices[sell] - stockPrices[buy];
            }

            // Return the maximum profit found.
            return Math.Max(0, maxProfit);
        }
        public static void Compute()
        {
            int[][] stockPricesArray = 
            { 
                new int[] { 1,2,4,2,5,7,2,4,9,0,9 },
                new int[] { 7,1,5,3,6,4 },
                new int[] { 7,6,4,3,1 },
                new int[] { 2,6,8,7,8,7,9,4,1,2,4,5,8 },
                new int[] { 1,4,2 }
            };

            foreach (int[] stockPrices in stockPricesArray)
            {
                Console.WriteLine("Input \t[" + string.Join(", ", stockPrices) + "]");
                Console.WriteLine("Output \t" + MaxProfit(stockPrices));
            }
        }
    }
}
