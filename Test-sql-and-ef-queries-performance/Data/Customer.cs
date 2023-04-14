namespace Test_sql_and_ef_queries_performance.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderCount { get; set; }
        public List<Order> Orders { get; set; }
    }
}
