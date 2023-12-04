using System;
using System.Collections.Generic;
using MyFirstApp.ConsoleApp;
namespace OOPTryouts
{
    abstract class ShopGoods
    {   
        public string Id { get; private set; }
        public double Price { get; private set; }
        public string Name { get; private set; }

        public ShopGoods(string Id, double Price, string Name)
        {
            this.Id = Id;
            this.Price = Price;
            this.Name = Name;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Информация о товаре: {Name}, цена: {Price}, артикул товара: {Id}");
        }
    }

    abstract class ElectronicGoods : ShopGoods
    {
        
        public int WarrantyMonths { get; private set; }

        public ElectronicGoods(string Id, double Price, string Name, int WarrantyMonths) : base(Id, Price, Name)
        {

            this.WarrantyMonths = WarrantyMonths;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Срок гарантии (мес): {WarrantyMonths}");
        }
    }

    abstract class ComputerParts : ElectronicGoods
    {
        public enum Segment
        {
            budget,
            common,
            office,
            premium,
            gamer
        }

        public Segment HardwareSegment { get; private set; }

        public ComputerParts(string Id, double Price, string Name, int WarrantyMonths, Segment HardwareSegment) : base(Id, Price, Name, WarrantyMonths)
        {
            this.HardwareSegment = HardwareSegment;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Сегмент: {HardwareSegment}");
        }
    }
    class MotherBoards : ComputerParts
    {
        public string Socket { get; private set; }

        public MotherBoards(string Id, double Price, string Name, int WarrantyMonths, Segment HardwareSegment, string Socket) : base(Id, Price, Name, WarrantyMonths, HardwareSegment)
        {
            this.Socket = Socket;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Сокет: {Socket}");
        }

    }
    class GPUS : ComputerParts
    {
        public double PCIeVersion { get; private set; }

        public GPUS(string Id, double Price, string Name, int WarrantyMonths, Segment HardwareSegment, double PCIeVersion) : base(Id, Price, Name, WarrantyMonths, HardwareSegment)
        {
            this.PCIeVersion = PCIeVersion;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Версия PCIe: {PCIeVersion}");
        }
    }
    abstract class Furniture : ShopGoods
    {
        public enum Color
        {
            white,
            black,
            red,
            green,
            gray
        }

        public Color FurnitureColor { get; private set; }
        public double SideASize { get; private set; }
        public double SideBSize { get; private set; }
        public double SideCSize { get; private set; }

        public Furniture(string Id, double Price, string Name, Color FurnitureColor, double SideASize, double SideBSize, double SideCSize) : base(Id, Price, Name)
        {
            this.SideASize = SideASize;
            this.SideBSize = SideBSize;
            this.SideCSize = SideCSize;
            this.FurnitureColor = FurnitureColor;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Цвет: {FurnitureColor}, Размеры: {SideASize}x{SideBSize}x{SideCSize}");
        }

    }

    class Sofa : Furniture
    {
        public Sofa(string Id, double Price, string Name, Color FurnitureColor, double SideASize, double SideBSize, double SideCSize, int PersonasCount) : base(Id, Price, Name, FurnitureColor, SideASize, SideBSize, SideCSize)
        {
            this.PersonasCount = PersonasCount;
        }

        public int PersonasCount { get; private set; }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Количество спальных мест: {PersonasCount}");
        }

    }

    class PriceList<TItem> where TItem : ShopGoods
    {
        private readonly TItem[] goodsPriceListArray;

        public PriceList(TItem[] goodsPriceListArray)
        {
            this.goodsPriceListArray = goodsPriceListArray;
        }

        public TItem this[int index]
        {
            get
            {

                if (index >= 0 && index < goodsPriceListArray.Length)
                {
                    return goodsPriceListArray[index];
                }
                else
                {
                    return null;
                }
            }
        }

        public TItem this[string Id]
        {
            get
            {
                for (int i = 0; i < goodsPriceListArray.Length; i++)
                {
                    if (goodsPriceListArray[i].Id == Id)
                    {
                        return goodsPriceListArray[i];
                    }
                }
                return null;
            }
        }


        public void ShowGoodsInPriceList()
        {
            int i = 1;
            foreach (var item in goodsPriceListArray)
            {
                Console.WriteLine($"Товар номер {i}. ");
                item.ShowInfo();
                Console.WriteLine();
                i++;
            }
        }
    }

    class Order<TDelivery> where TDelivery : Delivery
    {

        public double FullOrderPrice { get; private set; }
        public TDelivery ThisUserDelivery { get; private set; }


        public Order(TDelivery thisUserDelivery, double cartSum)
        {
            ThisUserDelivery = thisUserDelivery;
            FullOrderPrice = cartSum + ThisUserDelivery.DeliveryPrice;
        }

    }

    abstract class Delivery
    {
        public virtual double MinimumSumForFreeDelivery { get; private protected set; }
        public string Address { get; private protected set; }
        public virtual double DeliveryPrice { get; private protected set; }

        internal void SettingDeliveryPrice(double cartSum)
        {
            if (cartSum > MinimumSumForFreeDelivery)
            {
                DeliveryPrice = 0;
            }
        }
        public virtual void PrintDeliveryInfo()
        {
            Console.WriteLine($"Информация о доставке: ");
        }

    }

    class HomeDelivery : Delivery
    {
        public HomeDelivery()
        {
            Address = "Санкт-Петербург, улица Пушкина, дом Колотушкина, квартира три, нос подотри, хохохаха";
            MinimumSumForFreeDelivery = 1000d;

        }

        public override void PrintDeliveryInfo()
        {
            base.PrintDeliveryInfo();
            Console.WriteLine($"Доставляем на дом, адрес: {Address}, минимальная сумма заказа для бесплатной доставки: {MinimumSumForFreeDelivery}");
        }

        public override double DeliveryPrice { get; private protected set; }
    }

    class PickPointDelivery : Delivery
    {
        public PickPointDelivery()
        {
            MinimumSumForFreeDelivery = 1000d;
            Address = "Санкт-Петербург, пикпойнт у автомата, не приходи без травмата";
        }

        public override void PrintDeliveryInfo()
        {
            base.PrintDeliveryInfo();
            Console.WriteLine($"Доставляем в точку выдачи, адрес: {Address}, минимальная сумма заказа для бесплатной доставки: {MinimumSumForFreeDelivery}");
        }
    }

    class ShopDelivery : Delivery
    {
        private Dictionary<int, string> shopCodes = new Dictionary<int, string>()
        {
            { 1, "Кудрово, улица Дыбенко, я б отсюда не забирал" },
            {2, "улица Думская, отсюда я бы тем болеее не забирал" },
            {3, "Невский проспект, а вот тут точка хорошая, по дефолту везём сюда" }
        };

    public ShopDelivery(int shopNumber)
        {
            MinimumSumForFreeDelivery = 1000d;
            if(shopNumber != 1 && shopNumber != 2 && shopNumber != 3)
            {
                shopNumber = 3;
            }
            Address = $"Санкт-Петербург, {shopCodes[shopNumber]}";

        }

        public override void PrintDeliveryInfo()
        {
            base.PrintDeliveryInfo();
            Console.WriteLine($"Доставляем в розничный магазин, адрес: {Address}, график работы: 24/7 открыт ващеееее всегда! ");
        }
    }

    sealed class User<TShopGoods> where TShopGoods : ShopGoods
    {
        public const int Min_Email_Length = 5;
        public const int Max_Email_Length = 20;

        public const int Min_Phone_Number_Length = 10;
        public const int Max_Phone_Number_Length = 15;

        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                name = (value == "") ? "Имя Фамилия" : value;
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            private set
            {
                if (value.Length < Min_Email_Length || value.Length > Max_Email_Length || !value.Contains("@") || !value.Contains("."))
                {
                    email = "e-mail не введён";
                }
                else
                {
                    email = value;
                }
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            private set
            {
                if (value.Length < Min_Phone_Number_Length || value.Length > Max_Phone_Number_Length || value[0] != '+' || !double.TryParse(value.Substring(1), out _))
                {
                    phoneNumber = "номер телефона не введён";
                }
                else
                {
                    phoneNumber = value;
                }
            }
        }

        public void SettingUserName()
        {
            Console.WriteLine("Введите ваше имя: ");
            Name = Console.ReadLine();
        }

        public void SettingUserEmail()
        {
            Console.WriteLine("Введите вашу почту: ");
            Email = Console.ReadLine();

        }

        public void SettingUserPhoneNumber()
        {
            Console.WriteLine("Введите ваш номер телефона: ");
            PhoneNumber = Console.ReadLine();

        }


        public UserManager<TShopGoods> ThisUserManager { get; }

        public User()
        {
            ThisUserManager = new UserManager<TShopGoods>();
            SettingUserName();
            SettingUserEmail();
            SettingUserPhoneNumber();
        }


    }

    sealed class Cart<TShopGoods> where TShopGoods : ShopGoods
    {
        public List<TShopGoods> CartAsList { get; private set; }

        private PriceList<TShopGoods> CurrentPriceList { get; set; }
        public void AddToCart()
        {
            Console.WriteLine("Введите артикул товара, который нужно добавить: ");
            var userChoice = Console.ReadLine();
            while (CurrentPriceList[userChoice] == null)
            {
                Console.WriteLine("Нет товара в прайслисте с таким артикулом, попробуйте снова:  ");
                userChoice = Console.ReadLine();
            }
            if (CartAsList.Contains(CurrentPriceList[userChoice]))
            {
                Console.WriteLine("Этот товар уже есть в корзине! ");
                AddToCart();
            }

            {
                CartAsList.Add(CurrentPriceList[userChoice]);
                Console.WriteLine($"Товар {CurrentPriceList[userChoice].Name} успешно добавлен!");
            }

        }
        public void RemoveFromCart()
        {
            Console.WriteLine("Введите артикул товара, который вы хотите удалить из корзины: ");
            var userChoice = Console.ReadLine();
            while (CurrentPriceList[userChoice] == null)
            {
                Console.WriteLine("Нет товара в прайслисте с таким артикулом, попробуйте снова: ");
                userChoice = Console.ReadLine();
            }
            while (!CartAsList.Contains(CurrentPriceList[userChoice]))
            {
                Console.WriteLine("В корзине нет такого товара, попробуйте снова: ");
                userChoice = Console.ReadLine();
            }

            CartAsList.Remove(CurrentPriceList[userChoice]);
            Console.WriteLine($"Товар {CurrentPriceList[userChoice].Name} успешно удален из корзины!");

        }
        public void ShowingItemsInCart()
        {
            int i = 1;
            foreach (var item in CartAsList)
            {
                Console.WriteLine($"{i}: {item.Name}, стоимость {item.Price}");
                i++;
            }
        }

        public double CartSumCalculator()
        {
            double result = 0d;
            foreach (var item in CartAsList)
            {
                result += item.Price;
            }
            return result;
        }

        public Cart()
        {
            CartAsList = new List<TShopGoods>();
            CurrentPriceList = UserManager<TShopGoods>.PriceListToWorkWith;
        }

    }

    sealed class UserManager<TShopGoods> where TShopGoods : ShopGoods
    {
        public const string Choice_To_Add = "1";
        public const string Choice_To_Remove = "2";
        public const string Choice_To_Pay_Or_Close = "0";

        public const string Choice_Delivery_Home = "1";
        public const string Choice_Delivery_PickPoint = "2";
        public const string Choice_Delivery_Shop = "3";
        public static PriceList<TShopGoods> PriceListToWorkWith
        {
            get; private set;
        }
        public Delivery ThisUserDelivery { get; private set; }
        public Order<Delivery> ThisUserOrder { get; private set; }
        public Cart<TShopGoods> ThisUserCart { get; private set; }

        internal static void PriceListForAllUsersSetter(PriceList<TShopGoods> priceList)
        {
            PriceListToWorkWith = priceList;
        }
        public void ChooseAddOrRemoveOrCheckout(string option1, string option2)
        {
            Console.WriteLine($"Введите {option1}, чтоб добавить товар в корзину. Введите {option2}, чтоб выйти из программы: ");
            string userChoice = Console.ReadLine();
            while (userChoice != option1 && userChoice != option2)
            {
                Console.WriteLine("неверный инпут, попробуйте снова:  ");
                userChoice = Console.ReadLine();
            }
            if (userChoice == option2)
            {
                Console.WriteLine("Корзина пуста, выходим из программы ");
            }
            else if (userChoice == option1)
            {
                ThisUserCart.AddToCart();
                CheckingWhatOptionsToOffer();
            }

        }
        public void ChooseAddOrRemoveOrCheckout(string option1, string option2, string option3)
        {
            Console.WriteLine($"Введите {option1}, чтоб добавить товар в корзину. Введите {option2}, чтоб удалить товар из корзины. Введите {option3}, чтоб перейти к оплате: ");
            string userChoice = Console.ReadLine();
            while (userChoice != option1 && userChoice != option2 && userChoice != option3)
            {
                Console.WriteLine("неверный инпут, попробуйте снова! ");
                userChoice = Console.ReadLine();
            }
            if (userChoice == option3)
            {
                Console.WriteLine("Переходим к покупкам ");
                CreatingOrder();
            }
            else if (userChoice == option1)
            {
                ThisUserCart.AddToCart();
                CheckingWhatOptionsToOffer();
            }
            else if (userChoice == option2)
            {
                ThisUserCart.RemoveFromCart();
                CheckingWhatOptionsToOffer();
            }

        }
        public void ChooseAddOrRemoveOrCheckout()
        {
            Console.WriteLine("В корзину добавлены все товары в прайс-листе, больше добавить не получится! ");
            Console.WriteLine($"Введите {Choice_To_Remove}, чтоб удалить товар из корзины. Введите {Choice_To_Pay_Or_Close}, чтоб перейти к оплате");
            string userChoice = Console.ReadLine();

            while (userChoice != Choice_To_Remove && userChoice != Choice_To_Pay_Or_Close)
            {
                Console.WriteLine("неверный инпут, попробуйте снова: ");
                userChoice = Console.ReadLine();
            }
            if (userChoice == Choice_To_Remove)
            {
                ThisUserCart.RemoveFromCart();
                CheckingWhatOptionsToOffer();
            }
            else if (userChoice == Choice_To_Pay_Or_Close)
            {
                Console.WriteLine("Переходим к покупкам ");
                CreatingOrder();
            }

        }
        private void CreatingOrder()
        {
            Console.WriteLine($"Введите {Choice_Delivery_Home}, чтоб выбрать доставку на дом, {Choice_Delivery_PickPoint} для доставки в пункт выдачи, {Choice_Delivery_Shop} для самовывоза из магазина:");
            string userInput = Console.ReadLine();
            while (userInput != Choice_Delivery_Home && userInput != Choice_Delivery_PickPoint && userInput != Choice_Delivery_Home)
            {
                Console.WriteLine("Неверный инпут, введите заново! ");
                userInput = Console.ReadLine();
            }
            if (userInput == Choice_Delivery_Home)
            {
                ThisUserDelivery = new HomeDelivery();

            }
            else if (userInput == Choice_Delivery_PickPoint)
            {
                ThisUserDelivery = new PickPointDelivery();
            }
            else if (userInput == Choice_Delivery_Shop)
            {
                ThisUserDelivery = new ShopDelivery(shopNumber: 3);
            }
            double thisUserCartSum = ThisUserCart.CartSumCalculator();
            ThisUserDelivery.SettingDeliveryPrice(cartSum: thisUserCartSum);
            ThisUserOrder = new Order<Delivery>(thisUserDelivery: ThisUserDelivery, cartSum: thisUserCartSum);
            ShowFullOrderDeliveryInfo();
        }
        public void CheckingWhatOptionsToOffer()
        {
            if (ThisUserCart.CartAsList.Count == 0)
            {
                ChooseAddOrRemoveOrCheckout(option1: Choice_To_Add, option2: Choice_To_Pay_Or_Close);
            }
            else if (ThisUserCart.CartAsList.Count == 3)
            {
                ChooseAddOrRemoveOrCheckout();
            }
            else
            {
                ChooseAddOrRemoveOrCheckout(option1: Choice_To_Add, option2: Choice_To_Remove, option3: Choice_To_Pay_Or_Close);
            }
        }

        public void ShowFullOrderDeliveryInfo()
        {
            Console.WriteLine("\nВаш заказ принят! Содержимое заказа: ");
            ThisUserCart.ShowingItemsInCart();
            Console.WriteLine();
            ThisUserDelivery.PrintDeliveryInfo();
            Console.WriteLine($"Полная стоимость, заказа, включая доставку: {ThisUserOrder.FullOrderPrice}" );
        }
        public UserManager()
        {
            ThisUserCart = new Cart<TShopGoods>();
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Sofa sofa000001 = new Sofa(Id: "000001", Price: 30000d, Name: "Диван чёрный двуспальный", FurnitureColor: Furniture.Color.black, SideASize: 200, SideBSize: 80, SideCSize: 150, PersonasCount: 2);
            MotherBoards motherboard000002 = new MotherBoards(Id: "000002", Price: 25300d, Name: "Материнская плата ХЗХЗ", WarrantyMonths: 24, HardwareSegment: ComputerParts.Segment.gamer, Socket: "AM4");
            GPUS gpu000003 = new GPUS(Id: "000003", Price: 325300d, Name: "Видеокарта 100500ПЫЩПЫЩ", WarrantyMonths: 36, HardwareSegment: ComputerParts.Segment.premium, PCIeVersion: 4.0);

            var shopItemsArray = new ShopGoods[]
            {
            sofa000001, motherboard000002, gpu000003
            };

            PriceList<ShopGoods> mainPriceList = new PriceList<ShopGoods>(shopItemsArray);
            UserManager<ShopGoods>.PriceListForAllUsersSetter(mainPriceList);
            User<ShopGoods> user = new User<ShopGoods>();
            user.UserInfo();
            user.ThisUserManager.CheckingWhatOptionsToOffer();

            Console.ReadKey();

        }
    }
}



