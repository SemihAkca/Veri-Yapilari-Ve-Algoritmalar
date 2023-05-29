
using BHeapAppWithProducts;
using Newtonsoft.Json;
using PriorityQueue;

var products = GetProducts();
foreach (var product in products)
{
    Console.WriteLine($"{product.Id}  {product.ProductName}  {product.Price}");
}

Console.WriteLine(new string('-',60));

var productArray = GetTopProducts(7);
foreach (var product in productArray)
{
    Console.WriteLine($"{product.Id}  {product.ProductName}  {product.Price}");

}



MaxHeap<Product> GetProducts()
{

    var data = File.ReadAllText("C:\\Users\\win10\\Desktop\\MYAZ206\\Veri_Yapıları_Ve_Algoritmalar\\Apps\\BHeapAppWithProducts\\Products.json");
    
    var rootObject = new { Products = new List<Product>() };
    var deserializedData = JsonConvert.DeserializeAnonymousType(data, rootObject);
    var productList = deserializedData.Products;
    
    var products = new MaxHeap<Product>(productList);
    
    return products;
}

// n sayısı kadar en pahalı ürünleri veren metot
Product[] GetTopProducts(int n)
{
    //    var products = GetProducts().OrderByDescending(p => p.Price).Take(n);
    //    return products.ToArray();

    var productArray = new Product[n];

    for (int i = 0; i < n; i++)
    {
        productArray[i] = products.DeleteMinMax();
    }
    return productArray;
}
