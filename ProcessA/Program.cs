namespace ProcessA;

using FFFP_POC_Core;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Process A - I supply products");

        // Init domaine class
        Domain domainclass = new Domain();
        domainclass.Products = getDummyData();

        //domainclass.ExportProducts("AnExport.json");

        // Keeps the application alive.
        while(true)
        {
            Task.Delay(500);
        }
    }


    // HELPERS

    private static List<Product> getDummyData()
    {
        return new List<Product>
        {
            new Product(1, "Dell XPS 15", "A very capable work machine"),
            new Product(2, "MacBook Pro 14", "M3 chip powerhouse for creators"),
            new Product(3, "Logitech MX Master 3S", "Ergonomic wireless mouse with silent clicks"),
            new Product(4, "Samsung Odyssey G9", "49-inch curved gaming monitor"),
            new Product(5, "Keychron K2", "Mechanical keyboard with RGB backlighting"),
            new Product(6, "Sony WH-1000XM5", "Industry-leading noise canceling headphones"),
            new Product(7, "Apple Watch Ultra 2", "Rugged smartwatch for outdoor athletes"),
            new Product(8, "Kindle Paperwhite", "Waterproof e-reader with 6.8-inch display"),
            new Product(9, "GoPro HERO12", "Action camera with HDR video support"),
            new Product(10, "Nintendo Switch OLED", "Portable gaming console with vibrant screen"),
            new Product(11, "ASUS ROG Zephyrus G14", "Compact yet powerful gaming laptop"),
            new Product(12, "SteelSeries Arctis Nova Pro", "High-fidelity gaming headset"),
            new Product(13, "Blue Yeti USB Mic", "Professional microphone for streaming"),
            new Product(14, "Elgato Stream Deck MK.2", "15 customizable LCD keys for workflows"),
            new Product(15, "LG C3 OLED TV", "4K Smart TV perfect for gaming and movies"),
            new Product(16, "iPad Pro 12.9", "Liquid Retina XDR display with M2 chip"),
            new Product(17, "Bose QuietComfort Ultra", "Premium spatial audio headphones"),
            new Product(18, "Razer DeathAdder V3", "Ultra-lightweight competitive gaming mouse"),
            new Product(19, "Microsoft Surface Pro 9", "2-in-1 tablet and laptop versatility"),
            new Product(20, "Sonos Era 100", "Smart speaker with room-filling sound"),
            new Product(21, "DJI Mini 4 Pro", "Ultralight folding drone with 4K camera"),
            new Product(22, "Anker 737 Power Bank", "High-speed charging portable battery"),
            new Product(23, "Western Digital 4TB HDD", "Reliable external storage for backups"),
            new Product(24, "Crucial T700 Gen5 SSD", "Blazing fast NVMe internal storage"),
            new Product(25, "Philips Hue Starter Kit", "Smart lighting system for the home"),
            new Product(26, "Ring Video Doorbell", "Smart security camera for your front door"),
            new Product(27, "Nest Learning Thermostat", "Energy-saving smart home temperature control"),
            new Product(28, "Ember Mug 2", "Temperature-controlled smart coffee mug"),
            new Product(29, "Fitbit Charge 6", "Advanced fitness and health tracker"),
            new Product(30, "Garmin Fenix 7 Pro", "Multisport GPS watch for serious training"),
            new Product(31, "HyperX QuadCast S", "USB condenser mic with RGB lighting"),
            new Product(32, "Corsair Vengeance 32GB RAM", "High-performance DDR5 memory modules"),
            new Product(33, "NVIDIA RTX 4080 Super", "High-end graphics card for 4K gaming"),
            new Product(34, "AMD Ryzen 9 7950X", "16-core desktop processor for heavy tasks"),
            new Product(35, "NZXT H7 Flow Case", "Mid-tower case with high airflow design"),
            new Product(36, "Be Quiet! Dark Rock Pro 4", "Quiet and efficient air CPU cooler"),
            new Product(37, "EVGA SuperNOVA 850W", "80 Plus Gold modular power supply"),
            new Product(38, "TP-Link Deco XE75", "AXE5400 Tri-Band Mesh Wi-Fi 6E system"),
            new Product(39, "Roku Streaming Stick 4K", "Portable 4K streaming device with HDR"),
            new Product(40, "Secretlab Titan Evo", "Ergonomic gaming chair for long sessions"),
            new Product(41, "Herman Miller Aeron", "The gold standard for ergonomic office chairs"),
            new Product(42, "Fully Jarvis Standing Desk", "Motorized desk for sit-to-stand work"),
            new Product(43, "Oculus Quest 3", "All-in-one VR headset with mixed reality"),
            new Product(44, "Steam Deck 512GB", "Valve's handheld PC gaming device"),
            new Product(45, "AirPods Pro Gen 2", "In-ear headphones with MagSafe charging"),
            new Product(46, "Beat Studio Pro", "Over-ear headphones with USB-C audio"),
            new Product(47, "Sennheiser HD 660S2", "Open-back audiophile headphones"),
            new Product(48, "Focusrite Scarlett 2i2", "Industry-standard audio interface"),
            new Product(49, "Shure SM7B", "Professional dynamic vocal microphone"),
            new Product(50, "Nanoleaf Lines", "Modular backlit smart light bars"),
            new Product(51, "iRobot Roomba j7+", "Self-emptying robot vacuum cleaner"),
            new Product(52, "Dyson V15 Detect", "Cordless vacuum with laser dust detection"),
            new Product(53, "KitchenAid Artisan Mixer", "Iconic stand mixer for home baking"),
            new Product(54, "Nespresso Vertuo Next", "Versatile capsule coffee and espresso maker"),
            new Product(55, "Instant Pot Pro", "10-in-1 multi-cooker and pressure cooker"),
            new Product(56, "Breville Barista Express", "All-in-one espresso machine with grinder"),
            new Product(57, "Lutron Caseta Dimmer", "Reliable smart lighting wall switch"),
            new Product(58, "Wyze Cam v3", "Affordable indoor/outdoor security camera"),
            new Product(59, "August Wi-Fi Smart Lock", "Keyless entry for your existing deadbolt"),
            new Product(60, "Tile Pro (2022)", "Bluetooth tracker for keys and bags"),
            new Product(61, "Peloton Bike+", "Premium indoor cycling with large screen"),
            new Product(62, "Theragun Elite", "Percussive therapy deep tissue massager"),
            new Product(63, "Withings Body Scan", "Advanced smart scale with ECG and nerve health"),
            new Product(64, "Oral-B iO Series 9", "Electric toothbrush with AI tracking"),
            new Product(65, "Dyson Supersonic", "High-speed hair dryer with heat protection"),
            new Product(66, "Timbuk2 Command Bag", "Durable messenger bag for tech commuters"),
            new Product(67, "Peak Design Everyday Backpack", "Versatile bag for photographers and travelers"),
            new Product(68, "Bellroy Classic Backpack", "Minimalist design with internal organization"),
            new Product(69, "Yeti Rambler 30oz", "Insulated stainless steel tumbler"),
            new Product(70, "Hydro Flask 32oz", "Wide mouth water bottle with straw lid"),
            new Product(71, "Patagonia Better Sweater", "Recycled polyester fleece jacket"),
            new Product(72, "Arc'teryx Atom LT", "Lightweight insulated hooded jacket"),
            new Product(73, "North Face Recon", "Classic durable outdoor backpack"),
            new Product(74, "Leatherman Wave Plus", "Multitool with 17 essential tools"),
            new Product(75, "Black Diamond Spot 400", "Powerful headlamp for hiking and camping"),
            new Product(76, "Stanley Adventure Quencher", "Viral insulated tumbler with handle"),
            new Product(77, "BioLite CampStove 2+", "Wood burning stove that charges phones"),
            new Product(78, "MSR PocketRocket 2", "Ultralight backpacking pressure stove"),
            new Product(79, "Thermacell E55", "Rechargeable mosquito repeller"),
            new Product(80, "Goal Zero Nomad 10", "Portable solar panel for USB charging"),
            new Product(81, "Wacom Intuos Pro", "Professional pen tablet for digital art"),
            new Product(82, "Brother HL-L2350DW", "Compact laser printer for home offices"),
            new Product(83, "Canon EOS R6 Mark II", "Full-frame mirrorless camera body"),
            new Product(84, "Sigma 24-70mm f/2.8", "Versatile zoom lens for mirrorless"),
            new Product(85, "SanDisk 128GB Extreme", "High-speed SDXC card for 4K video"),
            new Product(86, "Manfrotto BeFree GT", "Travel-friendly carbon fiber tripod"),
            new Product(87, "Rode VideoMic Pro+", "On-camera shotgun microphone"),
            new Product(88, "Lowepro ProTactic 450", "Tactical camera backpack for pro gear"),
            new Product(89, "Zoom H5 Recorder", "Handheld portable multitrack recorder"),
            new Product(90, "Lacie Rugged 2TB SSD", "Drop and water resistant external drive"),
            new Product(91, "Philips Sonicare 9900", "Premium electric toothbrush with app support"),
            new Product(92, "Lululemon The Mat 5mm", "Non-slip natural rubber yoga mat"),
            new Product(93, "Manduka PRO Yoga Mat", "High-density cushion for joint protection"),
            new Product(94, "Bowflex SelectTech 552", "Adjustable dumbbells for home gyms"),
            new Product(95, "Concept2 RowErg", "Standard-setting indoor rowing machine"),
            new Product(96, "TRX Suspension Trainer", "Bodyweight workout system for travel"),
            new Product(97, "Hydro Flask Food Jar", "Insulated container for hot or cold meals"),
            new Product(98, "Larq Bottle PureVis", "Self-cleaning water bottle with UV light"),
            new Product(99, "Rocketbook Smart Notebook", "Reusable notebook that uploads to the cloud"),
            new Product(100, "Moleskine Classic", "Hardcover notebook for sketching and notes")
        };
    }

}