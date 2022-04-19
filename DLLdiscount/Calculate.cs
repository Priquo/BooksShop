using System;

namespace DLLdiscount
{
    public class Calculate
    {
        public float MakeDiscount(int countBook, float baseCost)
        {
            float discount = 0;
            if (countBook >= 10)
                discount = 0.15f;
            else if (countBook >= 5)
                discount = 0.1f;
            else if (countBook >= 3)
                discount = 0.05f;
            if (baseCost / 500 > 1)
                for (int i = 0; i < baseCost / 500; i++)
                    discount += 0.01f;
            return discount;
        }
    }
}
