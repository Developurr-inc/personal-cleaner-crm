namespace Orderly.Domain.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Product
    {
        public const string Code = "code";
        public const string Name = "ProductName";
        public const string Packaging = "packaging";
        public const decimal ExciseTax = 20;
        public const decimal PriceValue = 100;
    }

    public static class InvalidProduct
    {
        public const string ShortName = "fSnK";
        public const string LongName = "Ul5mnaAXaETpjPfUDnTMAJCwYEtT7yjwHeEMVlcd401wfkd7DHTu1ObVT2KpiiOuJihTok56xn0Q1QGTMJc4u21N1RmiavrzECI0Ypz4FvUwSOVTSd6rlZe3NcJHfntSsr9HWQx2c8n5UIlStFQ2YVFZeCZd7UvfyWSwoyKdMIAaP78JAbaqgLtD0HXGiZJPdcJWVbWuiOXfCWlRuIc28WZ72mGPY7sYfGZ5Bepj5ZgD8uqzLACy4ty5rdclvMpm\n";
        //public const decimal InvalidNegativeExciseTax = -1;
        //public const decimal InvalidNullExciseTax = 0;
    } 
}