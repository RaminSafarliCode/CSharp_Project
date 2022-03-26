using FinalProject.Infrustucture;
using FinalProject.Manager;
using System;
using System.Linq;

namespace FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Car System";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to the Car System! You can add cars to the system by adding some specifications...");
            Console.ResetColor();

            var brandMem = new BrandManager();
            var modelMem = new ModelManager();
            var carMem = new CarManager();

        goMenu:
            PrintMenu();

            Menu menuNum = ScannerManager.ReadMenu("Choose an operation from menu: ");

            switch (menuNum)
            {
                #region BrandAdd
                case Menu.BrandAdd:
                    Console.Clear();
                checkagain:
                    string nameBr = ScannerManager.ReadString("Enter the name of brand: ");
                    brandMem.CheckBrandName(nameBr);
                    if (brandMem.CheckBrandName(nameBr) == false)
                    {
                        ScannerManager.PrintError("This name is already used! \n" +
                            "To try again click <Spacebar> | To return menu click any other key");

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.Spacebar)
                        {
                            goto checkagain;
                        }
                        else
                        {
                            goto goMenu;
                        }
                    }
                    else
                    {

                        Brand brand = new Brand();
                        brand.NameBrand = nameBr;
                        brandMem.Add(brand);
                    }
                    goto case Menu.BrandsAll;
                #endregion
                #region BrandEdit
                case Menu.BrandEdit:
                    Console.Clear();
                    ShowAllBrands(brandMem);
                    Console.WriteLine("************************************************");
                    Console.WriteLine("You are changing brand name...");
                    int value = ScannerManager.ReadInteger("Enter the ID of choosen brand: ");

                    var checkBrandEdit = brandMem.GetAll().FirstOrDefault(x => x.IdBrand == value);
                    if (checkBrandEdit == null)
                    {
                        ScannerManager.PrintError("This brand ID is not found");

                    click:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("To try again click <Spacebar> | To return menu click <Esc>");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.Spacebar)
                        {
                            goto case Menu.BrandEdit;
                        }
                        else if (click.Key == ConsoleKey.Escape)
                        {
                            goto goMenu;
                        }
                        else
                        {
                            goto click;
                        }
                    }

                    brandMem.EditBrand(value);

                    goto case Menu.BrandsAll;
                #endregion
                #region BrandRemove
                case Menu.BrandRemove:
                    Console.Clear();
                    ShowAllBrands(brandMem);
                    Console.WriteLine("************************************************");
                    int id = ScannerManager.ReadInteger("Enter the ID of brand to remove: ");
                    Brand b1 = brandMem.GetAll().FirstOrDefault(item => item.IdBrand == id);
                    brandMem.Remove(b1);

                    goto case Menu.BrandsAll;
                #endregion
                #region BrandSingle
                case Menu.BrandSingle:
                    Console.Clear();
                    ShowAllBrands(brandMem);
                    Console.WriteLine("************************************************");
                    int idValue = ScannerManager.ReadInteger("Enter the ID of choosen brand: ");

                    var checkBrandSingle = brandMem.GetAll().FirstOrDefault(x => x.IdBrand == idValue);
                    if (checkBrandSingle == null)
                    {
                        ScannerManager.PrintError("This brand ID is not found");

                    clickSingleB:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.Spacebar)
                        {
                            goto case Menu.BrandSingle;
                        }
                        else if (click.Key == ConsoleKey.Escape)
                        {
                            goto goMenu;
                        }
                        else
                        {
                            goto clickSingleB;
                        }
                    }
                    Console.Clear();
                    brandMem.GetSingleBrand(idValue);

                    goto goMenu;
                #endregion
                #region BrandsAll
                case Menu.BrandsAll:
                    Console.Clear();
                    ShowAllBrands(brandMem);

                    goto goMenu;
                #endregion
                #region ModelAdd
                case Menu.ModelAdd:
                    Console.Clear();
                    //Model model = new Model();

                checkModelAgain:
                    string nameMo = ScannerManager.ReadString("Enter the name of model: ");

                    modelMem.CheckModelName(nameMo);
                    if (modelMem.CheckModelName(nameMo) == false)
                    {
                        ScannerManager.PrintError("This name is already used! \n" +
                            "To try again click <Spacebar> | To return menu click any other key");

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.Spacebar)
                        {
                            goto checkModelAgain;
                        }
                        else
                        {
                            goto goMenu;
                        }
                    }
                    else
                    {
                        Model model = new Model();
                        model.NameModel = nameMo;

                    tryag:
                        ShowAllBrands(brandMem);
                        Console.WriteLine("************************************************");

                        model.IdBr = ScannerManager.ReadInteger("Enter the ID of brand: ");

                        var checkBrandId = brandMem.GetAll().FirstOrDefault(x => x.IdBrand == model.IdBr);
                        if (checkBrandId == null)
                        {
                            ScannerManager.PrintError("This brand ID is not found");
                        clickAddMod:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto tryag;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto goMenu;
                            }
                            else
                            {
                                goto clickAddMod;
                            }
                        }
                        modelMem.Add(model);
                    }

                    goto case Menu.ModelsAll;
                #endregion
                #region ModelEdit
                case Menu.ModelEdit:
                    Console.Clear();
                    ShowAllModels(modelMem);
                    Console.WriteLine("************************************************");
                    Console.WriteLine("To change model -> 1 | To change brand ID -> 2");
                    bool success = int.TryParse(Console.ReadLine(), out int modelChan);
                    if (success && modelChan == 1)
                    {
                        int valueMod = ScannerManager.ReadInteger("Enter the ID of choosen model: ");

                        var checkModel1Edit = modelMem.GetAll().FirstOrDefault(x => x.IdModel == valueMod);
                        if (checkModel1Edit == null)
                        {
                            ScannerManager.PrintError("This model ID is not found");

                        clicker2:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto case Menu.ModelEdit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto goMenu;
                            }
                            else
                            {
                                goto clicker2;
                            }
                        }

                        modelMem.EditModelName(valueMod);
                    }
                    else if (success && modelChan == 2)
                    {
                        int valueMod = ScannerManager.ReadInteger("Enter the ID of choosen model: ");

                        var checkModel1Edit = modelMem.GetAll().FirstOrDefault(x => x.IdModel == valueMod);
                        if (checkModel1Edit == null)
                        {
                            ScannerManager.PrintError("This model ID is not found");

                        clicker3:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto case Menu.ModelEdit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto goMenu;
                            }
                            else
                            {
                                goto clicker3;
                            }
                        }

                        ShowAllBrands(brandMem);
                        Console.WriteLine("************************************************");

                        int newBrand = ScannerManager.ReadInteger("Enter the new brand: ");

                        var checkNewBrandEdit = brandMem.GetAll().FirstOrDefault(x => x.IdBrand == newBrand);
                        if (checkNewBrandEdit == null)
                        {
                            ScannerManager.PrintError("This brand ID is not found");

                        goBack:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto case Menu.ModelEdit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto goMenu;
                            }
                            else
                            {
                                goto goBack;
                            }
                        }
                        modelMem.EditModelBrand(valueMod, newBrand);
                    }

                    goto case Menu.ModelsAll;
                #endregion
                #region ModelRemove
                case Menu.ModelRemove:
                    Console.Clear();
                    ShowAllModels(modelMem);
                    Console.WriteLine("************************************************");
                    int idModelRem = ScannerManager.ReadInteger("Enter the ID of brand to remove: ");
                    Model m1 = modelMem.GetAll().FirstOrDefault(item => item.IdModel == idModelRem);
                    modelMem.Remove(m1);

                    goto case Menu.ModelsAll;
                #endregion
                #region ModelSingle
                case Menu.ModelSingle:
                    Console.Clear();
                    ShowAllModels(modelMem);
                    Console.WriteLine("************************************************");
                    int idModel = ScannerManager.ReadInteger("Enter the ID of choosen model: ");

                    var checkModelSingle = modelMem.GetAll().FirstOrDefault(x => x.IdModel == idModel);
                    if (checkModelSingle == null)
                    {
                        ScannerManager.PrintError("This model ID is not found");

                    clickerSingle:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.Spacebar)
                        {
                            goto case Menu.ModelSingle;
                        }
                        else if (click.Key == ConsoleKey.Escape)
                        {
                            goto goMenu;
                        }
                        else
                        {
                            goto clickerSingle;
                        }
                    }

                    Console.Clear();
                    modelMem.GetSingleModel(idModel);

                    goto goMenu;
                #endregion
                #region ModelsAll
                case Menu.ModelsAll:
                    Console.Clear();
                    ShowAllModels(modelMem);

                    goto goMenu;
                #endregion
                #region CarAdd
                case Menu.CarAdd:
                    Console.Clear();
                    Car car = new Car();
                    car.Year = ScannerManager.ReadDate("Enter the release year: ");
                    car.Price = ScannerManager.ReadDouble("Enter the car price [$]: ");
                    car.Color = ScannerManager.ReadString("Enter the car color: ");
                    car.Engine = ScannerManager.ReadDouble("Enter the car engine: ");
                    PrintFuelMenu();
                    FuelType numFuel = ScannerManager.ReadFuelMenu("Select the type of fuel: ");
                    switch (numFuel)
                    {
                        case FuelType.Gasoline:
                            car.FuelType = nameof(FuelType.Gasoline);
                            break;
                        case FuelType.Diesel:
                            car.FuelType = nameof(FuelType.Diesel);
                            break;
                        case FuelType.Hybrid:
                            car.FuelType = nameof(FuelType.Hybrid);
                            break;
                        case FuelType.Electro:
                            car.FuelType = nameof(FuelType.Electro);
                            break;
                        case FuelType.Gas:
                            car.FuelType = nameof(FuelType.Gas);
                            break;
                        default:
                            ScannerManager.PrintError("Invalid operation! Please enter valid fuel type...");
                            break;
                    }

                tryagainAdd:
                    ShowAllModels(modelMem);
                    Console.WriteLine("************************************************");
                    car.IdMo = ScannerManager.ReadInteger("Enter the model ID: ");
                    var checkModelId = modelMem.GetAll().FirstOrDefault(x => x.IdModel == car.IdMo);
                    if (checkModelId == null)
                    {
                        ScannerManager.PrintError("This model ID is not found");

                    clickAdd:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.Spacebar)
                        {
                            goto tryagainAdd;
                        }
                        else if (click.Key == ConsoleKey.Escape)
                        {
                            goto goMenu;
                        }
                        else
                        {
                            goto clickAdd;
                        }
                    }
                    carMem.Add(car);

                    goto case Menu.CarsAll;
                #endregion
                #region CarEdit
                case Menu.CarEdit:
                    Console.Clear();
                    ShowAllCars(carMem);
                    Console.WriteLine("************************************************");

                    Console.WriteLine("To change release year -> 1 \n" +
                        "To change price -> 2 \n" +
                        "To change color -> 3 \n" +
                        "To change engine -> 4 \n" +
                        "To change fuel type -> 5 \n" +
                        "To change model -> 6");
                    bool successN = int.TryParse(Console.ReadLine(), out int carNumb);
                    if (successN && carNumb == 1)
                    {
                        int valueCar = ScannerManager.ReadInteger("Enter the ID of choosen car: ");

                        var checkCarEdit = carMem.GetAll().FirstOrDefault(x => x.IdCar == valueCar);
                        if (checkCarEdit == null)
                        {
                            ScannerManager.PrintError("This car ID is not found!");

                        click4:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto case Menu.CarEdit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto goMenu;
                            }
                            else
                            {
                                goto click4;
                            }
                        }

                        carMem.EditYear(valueCar);
                    }
                    else if (successN && carNumb == 2)
                    {
                        int valueCar = ScannerManager.ReadInteger("Enter the ID of choosen car: ");

                        var checkCarEdit = carMem.GetAll().FirstOrDefault(x => x.IdCar == valueCar);
                        if (checkCarEdit == null)
                        {
                            ScannerManager.PrintError("This car ID is not found!");

                        click5:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto case Menu.CarEdit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto goMenu;
                            }
                            else
                            {
                                goto click5;
                            }
                        }

                        carMem.EditPrice(valueCar);
                    }
                    else if (successN && carNumb == 3)
                    {
                        int valueCar = ScannerManager.ReadInteger("Enter the ID of choosen car: ");

                        var checkCarEdit = carMem.GetAll().FirstOrDefault(x => x.IdCar == valueCar);
                        if (checkCarEdit == null)
                        {
                            ScannerManager.PrintError("This car ID is not found!");

                        click6:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto case Menu.CarEdit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto goMenu;
                            }
                            else
                            {
                                goto click6;
                            }
                        }

                        carMem.EditColor(valueCar);
                    }
                    else if (successN && carNumb == 4)
                    {
                        int valueCar = ScannerManager.ReadInteger("Enter the ID of choosen car: ");

                        var checkCarEdit = carMem.GetAll().FirstOrDefault(x => x.IdCar == valueCar);
                        if (checkCarEdit == null)
                        {
                            ScannerManager.PrintError("This car ID is not found!");

                        click7:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto case Menu.CarEdit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto goMenu;
                            }
                            else
                            {
                                goto click7;
                            }
                        }

                        carMem.EditEngine(valueCar);

                    }
                    else if (successN && carNumb == 5)
                    {
                        int valueCar = ScannerManager.ReadInteger("Enter the ID of choosen car: ");

                        var checkCarEdit = carMem.GetAll().FirstOrDefault(x => x.IdCar == valueCar);
                        if (checkCarEdit == null)
                        {
                            ScannerManager.PrintError("This car ID is not found!");

                        click8:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto case Menu.CarEdit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto goMenu;
                            }
                            else
                            {
                                goto click8;
                            }
                        }

                        Console.Clear();
                        PrintFuelMenu();
                        carMem.EditFuelType(valueCar);
                    }
                    else if (successN && carNumb == 6)
                    {
                        int valueCar = ScannerManager.ReadInteger("Enter the ID of choosen car: ");

                        var checkCarEdit = carMem.GetAll().FirstOrDefault(x => x.IdCar == valueCar);
                        if (checkCarEdit == null)
                        {
                            ScannerManager.PrintError("This car ID is not found!");

                        click9:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto case Menu.CarEdit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto goMenu;
                            }
                            else
                            {
                                goto click9;
                            }
                        }

                        ShowAllModels(modelMem);
                        Console.WriteLine("************************************************");

                        int newModel = ScannerManager.ReadInteger("Enter the new model ID from list: ");
                        var checkNewModelEdit = modelMem.GetAll().FirstOrDefault(x => x.IdModel == newModel);
                        if (checkNewModelEdit == null)
                        {
                            ScannerManager.PrintError("This model ID is not found!");

                        goBackk:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto case Menu.CarEdit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto goMenu;
                            }
                            else
                            {
                                goto goBackk;
                            }
                        }

                        carMem.EditCarModel(valueCar, newModel);
                    }
                    else
                    {
                        ScannerManager.PrintError("Invalid Operation!");
                        goto case Menu.CarEdit;
                    }

                    goto case Menu.CarsAll;
                #endregion
                #region CarRemove
                case Menu.CarRemove:
                    Console.Clear();
                    ShowAllCars(carMem);
                    Console.WriteLine("************************************************");
                    int idCarRem = ScannerManager.ReadInteger("Enter the ID of car to remove: ");
                    Car c1 = carMem.GetAll().FirstOrDefault(item => item.IdCar == idCarRem);
                    carMem.Remove(c1);

                    goto case Menu.ModelsAll;
                #endregion
                #region CarSingle
                case Menu.CarSingle:
                    Console.Clear();
                    ShowAllCars(carMem);
                    Console.WriteLine("************************************************");
                    int idCar = ScannerManager.ReadInteger("Enter the ID of choosen car: ");

                    var checkCarSingle = carMem.GetAll().FirstOrDefault(x => x.IdCar == idCar);
                    if (checkCarSingle == null)
                    {
                        ScannerManager.PrintError("This car ID is not found!");

                    clickerCarSingle:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("To try again click <Spacebar> | To return menu click <Escape>");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.Spacebar)
                        {
                            goto case Menu.CarSingle;
                        }
                        else if (click.Key == ConsoleKey.Escape)
                        {
                            goto goMenu;
                        }
                        else
                        {
                            goto clickerCarSingle;
                        }
                    }
                    Console.Clear();
                    carMem.GetSingleCar(idCar);

                    goto goMenu;
                #endregion
                #region CarsAll
                case Menu.CarsAll:
                    Console.Clear();
                    ShowAllCars(carMem);

                    goto goMenu;
                #endregion
                #region All
                case Menu.All:
                    Console.Clear();
                    ShowAllBrands(brandMem);
                    ShowAllModels(modelMem);
                    ShowAllCars(carMem);

                    goto goMenu;
                #endregion
                #region Exit
                case Menu.Exit:
                    goto goEnd;
                #endregion
                #region Default
                default:
                    ScannerManager.PrintError("Invalid operation! Please enter valid menu...");
                    goto goMenu;
                #endregion
            }

        goEnd:
            Console.WriteLine("The program is finished!");
            Console.WriteLine("Please, click any key to close program!");
            Console.ReadKey();
        }
        static void PrintMenu()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            foreach (var item in Enum.GetNames(typeof(Menu)))
            {
                Menu m = (Menu)Enum.Parse(typeof(Menu), item);
                Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}. {item}");
            }
            Console.WriteLine($"{new string('-', Console.WindowWidth)}\n");
        }
        static void PrintFuelMenu()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            foreach (var item in Enum.GetNames(typeof(FuelType)))
            {
                FuelType m = (FuelType)Enum.Parse(typeof(FuelType), item);
                Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}. {item}");
            }
            Console.WriteLine($"{new string('-', Console.WindowWidth)}\n");
        }
        static void ShowAllBrands(BrandManager brandMem)
        {
            Console.WriteLine("******************** Brands ********************");
            foreach (var item in brandMem.GetAll())
            {
                Console.WriteLine(item);
            }
        }
        static void ShowAllModels(ModelManager modelMem)
        {
            Console.WriteLine("******************** Models ********************");
            foreach (var item in modelMem.GetAll())
            {
                Console.WriteLine(item);
            }
        }
        static void ShowAllCars(CarManager carMem)
        {
            Console.WriteLine("********************  Cars  ********************");
            foreach (var item in carMem.GetAll())
            {
                Console.WriteLine(item);
            }
        }
    }
}
