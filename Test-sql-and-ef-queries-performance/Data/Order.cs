namespace Test_sql_and_ef_queries_performance.Data
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
