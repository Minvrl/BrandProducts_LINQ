using Brands_proj.DAL;
using Brands_proj.Models;
using Microsoft.EntityFrameworkCore;

string opt;
do
{
    Console.WriteLine("\n====== MAIN MENU ====== ");
    Console.WriteLine("1. Add brand");
    Console.WriteLine("2. Get brand by id");
    Console.WriteLine("3. Get all brands");
    Console.WriteLine("4. Update brand");
    Console.WriteLine("5. Add product");
    Console.WriteLine("6. Get product by id");
    Console.WriteLine("7. Get all products");
    Console.WriteLine("8. Update product");
    Console.WriteLine("9. Remove product");
    Console.WriteLine("10. Remove brand");
    Console.WriteLine("0. Exit");

    opt = Console.ReadLine();

    BrandsDbContext context = new BrandsDbContext();

    string brandName,brandIdStr, productIdStr, foundstr, priceStr, prodName;
    double price;
    DateTime found;
    int brandId,productId;

    switch (opt)
    {
        case "1":
            Console.WriteLine("\n Add new brand \n =======================");
            do
            {
                Console.Write("Enter brand name - ");
                brandName = Console.ReadLine();

            } while (string.IsNullOrEmpty(brandName));
            do
            {
                Console.Write(" Founded at - ");
                foundstr = Console.ReadLine();

            } while (!DateTime.TryParse(foundstr,out found));

            var newBrand = new Brand
            {
                Name = brandName,
                FoundedAt = found
            };

            context.Brands.Add(newBrand);
            context.SaveChanges();
            Console.WriteLine("Brand added !");
            break;
        case "2":
            Console.WriteLine("\n Get brand by id \n =======================");
            do
            {
                Console.Write("Insert brand id - "  );
                brandIdStr = Console.ReadLine();
            } while (!int.TryParse(brandIdStr,out brandId) || brandId<0);
            var brand = context.Brands.Find(brandId);
            
            if (brand != null) Console.WriteLine(brand);
            else Console.WriteLine("Brand not found!");
            break;
        case "3":
            Console.WriteLine("\n ===== BRANDS =====");
            var brands = context.Brands.ToList();
            foreach (var item in brands)
            {
                Console.WriteLine(item);
            }
            break;
        case "4":
            Console.WriteLine("\n Update brand \n =======================");
            do
            {
                Console.Write("Insert brand id - ");
                brandIdStr = Console.ReadLine();
            } while (!int.TryParse(brandIdStr, out brandId) || brandId < 0);
            brand = context.Brands.Find(brandId);

            if (brand != null)
            {
                do
                {
                    Console.Write("Enter new brand name - ");
                    brandName = Console.ReadLine();

                } while (string.IsNullOrEmpty(brandName));
                brand.Name = brandName;
                context.SaveChanges();

                Console.WriteLine("Brand updated !");
                break;
            }
            else Console.WriteLine("Brand not found!");
            break;
        case "5":
            Console.WriteLine("\n Add product \n =======================");
            do
            {
                Console.Write("Enter product's name - "  );
                prodName = Console.ReadLine();
            } while (string.IsNullOrEmpty(prodName));
            do
            {
                Console.Write(" Price - ");
                priceStr = Console.ReadLine();
            } while (!double.TryParse(priceStr, out price) || price<0);
            foreach (var item in context.Brands.ToList())
                Console.WriteLine(item.Id + "-" + item.Name);
            do
            {
                Console.Write("  Enter brand id - ");
                brandIdStr = Console.ReadLine();
            } while (!int.TryParse(brandIdStr, out brandId) || brandId < 0);
            Product prd = new Product
            {
                Name = prodName,
                Price = price,
                BrandId = brandId
            };

            context.Products.Add(prd);
            context.SaveChanges();

            break;
        case "6":
            Console.WriteLine("\n Get product by id \n =======================");
            do
            {
                Console.Write("Insert product id - ");
                productIdStr = Console.ReadLine();
            } while (!int.TryParse(productIdStr,out productId) || productId<0);

            var foundPr = context.Products.Find(productId);
            if (foundPr != null) Console.WriteLine(foundPr);
            else Console.WriteLine("Product not found !");

            break;
        case "7":
            Console.WriteLine("\n ===== PRODUCTS =====");
            var prds = context.Products.ToList();
            foreach (var item in prds)
            {
                Console.WriteLine(item);
            }


            break;
        case "8":
            Console.WriteLine("\n Update product \n =======================");
            do
            {
                Console.Write("Insert product id - ");
                productIdStr = Console.ReadLine();
            } while (!int.TryParse(productIdStr, out productId) || productId < 0);
            var prodd = context.Products.Find(productId);

            if (prodd != null)
            {
                do
                {
                    Console.Write("Enter new product price - ");
                    priceStr = Console.ReadLine();

                } while (!double.TryParse(priceStr,out price) || price<0) ;
                prodd.Price = price;
                context.SaveChanges();

                Console.WriteLine("Price updated !");
                break;
            }
            else Console.WriteLine("Product not found!");
            break;
        case "9":
            Console.WriteLine("\n Remove product \n =======================");
            do
            {
                Console.Write("Insert product id to remove - ");
                productIdStr = Console.ReadLine();
            } while (!int.TryParse(productIdStr, out productId) || productId < 0);
            prodd = context.Products.Find(productId);

            if (prodd != null)
            {
                context.Products.Remove(prodd);
                context.SaveChanges();

                Console.WriteLine("Product removed !");
            }
            else Console.WriteLine("Product not found!");
            break;
        case "10":
            Console.WriteLine("\n Remove brand \n =======================");
            do
            {
                Console.Write("Insert brand id to remove - ");
                brandIdStr = Console.ReadLine();
            } while (!int.TryParse(brandIdStr, out brandId) || brandId < 0);
            brand = context.Brands.Find(brandId);

            if (brand != null) 
            {
                context.Brands.Remove(brand);
                context.SaveChanges();
                Console.WriteLine("Brand removed !");
            }
            else Console.WriteLine("Brand not found!");
            break;
        case "0":
            Console.WriteLine("Goodbye !");
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

} while (opt != "0");



















#region misc
//AddBrand();

//var r = GetAllBrands();

//Console.WriteLine("===== Brands =====");
//foreach (var item in r)
//{
//    Console.WriteLine(item);
//}


////Create brand
//void AddBrand()
//{
//    BrandsDbContext context = new BrandsDbContext();

//    var newBrand = new Brand
//    {
//        Name = "Porsche",
//        FoundedAt = new DateTime(1931, 04, 25)
//    };

//    context.Brands.Add(newBrand);
//    context.SaveChanges();
//}


////Get brands

//List<Brand> GetAllBrands()
//{
//    BrandsDbContext context = new BrandsDbContext();

//    return context.Brands.ToList();
//}


////Update

//void UpdateBrandName()
//{
//    BrandsDbContext context = new BrandsDbContext();

//    var brand = context.Brands.First();

//    brand.Name = "Miata";

//    context.SaveChanges();
//}

////Delete

//void DeleteBrand()
//{
//    BrandsDbContext context = new BrandsDbContext();

//    var brand = context.Brands.First();

//    context.Brands.Remove(brand);
//    context.SaveChanges();

//}
#endregion