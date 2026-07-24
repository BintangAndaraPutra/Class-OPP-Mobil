// ============================================================
// Program Utama - Demonstrasi 4 Pilar OOP (Object Oriented Programming)
// menggunakan tema Kelas Mobil
//
// 1. ENCAPSULATION  - Private fields, Property dengan validasi
// 2. INHERITANCE     - Kendaraan -> Mobil -> MobilSport / MobilListrik
// 3. POLYMORPHISM    - Virtual/Override method + Interface
// 4. ABSTRACTION     - Abstract class + Interface
//
// Nama    : [Nama Mahasiswa]
// NIM     : [NIM Mahasiswa]
// ============================================================

namespace MobilOOP
{
    class Program
    {
        // Helper methods untuk tampilan yang rapi
        static void CetakGaris(char karakter = '-', int panjang = 60)
        {
            Console.WriteLine(new string(karakter, panjang));
        }

        static void CetakJudul(string judul)
        {
            Console.WriteLine();
            CetakGaris('=');
            Console.WriteLine($"  {judul}");
            CetakGaris('=');
        }

        static void CetakSubJudul(string subjudul)
        {
            Console.WriteLine();
            CetakGaris('-');
            Console.WriteLine($"  {subjudul}");
            CetakGaris('-');
        }

        static void CetakPoin(string teks)
        {
            Console.WriteLine($"  > {teks}");
        }

        static void CetakInfo(string label, string nilai)
        {
            Console.WriteLine($"  {label,-18}: {nilai}");
        }

        static void Main(string[] args)
        {
            // ==================== HEADER ====================
            CetakGaris('=');
            Console.WriteLine();
            Console.WriteLine("   PROGRAM DEMONSTRASI 4 PILAR OOP - KELAS MOBIL");
            Console.WriteLine();
            CetakPoin("1. Encapsulation  (Enkapsulasi)");
            CetakPoin("2. Inheritance    (Pewarisan)");
            CetakPoin("3. Polymorphism   (Polimorfisme)");
            CetakPoin("4. Abstraction    (Abstraksi)");
            Console.WriteLine();
            CetakGaris('=');

            // ==============================================================
            // BAGIAN 1: ENCAPSULATION (Enkapsulasi)
            // ==============================================================
            CetakJudul("PILAR 1: ENCAPSULATION (Enkapsulasi)");
            CetakPoin("Field private tidak bisa diakses langsung dari luar kelas");
            CetakPoin("Akses melalui Property (getter/setter) dengan validasi");

            // Membuat objek Mobil
            Mobil avanza = new Mobil("Toyota Avanza", 2023, "Silver", 45.0, 4, "Otomatis");

            CetakSubJudul("Demonstrasi Property dengan Validasi");
            CetakInfo("Merk", avanza.Merk);
            CetakInfo("Tahun Produksi", avanza.TahunProduksi.ToString());
            CetakInfo("Warna", avanza.Warna);
            CetakInfo("Jumlah Pintu", avanza.JumlahPintu.ToString());
            CetakInfo("Transmisi", avanza.JenisTransmisi);
            CetakInfo("Bahan Bakar", $"{avanza.CekSisaBahanBakar()} liter");

            CetakSubJudul("Demonstrasi Validasi - Input Tidak Valid");
            avanza.Merk = "";                  // akan ditolak - merk kosong
            avanza.TahunProduksi = 1800;       // akan ditolak - tahun terlalu kecil
            avanza.JumlahPintu = 10;           // akan ditolak - pintu terlalu banyak
            avanza.JenisTransmisi = "CVT";     // akan ditolak - hanya Manual/Otomatis
            Console.WriteLine();
            CetakPoin($"(Nilai tetap tidak berubah)");
            CetakInfo("Merk", avanza.Merk);
            CetakInfo("Pintu", avanza.JumlahPintu.ToString());

            // ==============================================================
            // BAGIAN 2: INHERITANCE (Pewarisan)
            // ==============================================================
            CetakJudul("PILAR 2: INHERITANCE (Pewarisan)");
            CetakPoin("MobilSport mewarisi Mobil yang mewarisi Kendaraan");
            CetakPoin("MobilListrik mewarisi Mobil yang mewarisi Kendaraan");
            CetakPoin("Hierarki: Kendaraan -> Mobil -> MobilSport / MobilListrik");

            // Membuat objek dari kelas turunan
            MobilSport ferrari = new MobilSport("Ferrari 488 GTB", 2024, "Merah", 80.0, 2, "Otomatis", 670);
            MobilListrik tesla = new MobilListrik("Tesla Model 3", 2024, "Putih", 4, "Otomatis", 75.0, 60.0);

            CetakSubJudul("Info Mobil Biasa (kelas Mobil)");
            Console.WriteLine($"  {avanza.GetInfoKendaraan()}");

            CetakSubJudul("Info Mobil Sport (mewarisi Mobil + Kendaraan)");
            Console.WriteLine($"  {ferrari.GetInfoKendaraan()}");

            CetakSubJudul("Info Mobil Listrik (mewarisi Mobil + Kendaraan)");
            Console.WriteLine($"  {tesla.GetInfoKendaraan()}");

            CetakSubJudul("Demonstrasi method yang diwarisi dari kelas induk");
            avanza.Nyalakan();
            avanza.Jalan();
            avanza.Akselerasi(40);
            avanza.Berhenti();
            avanza.Matikan();

            // ==============================================================
            // BAGIAN 3: POLYMORPHISM (Polimorfisme)
            // ==============================================================
            CetakJudul("PILAR 3: POLYMORPHISM (Polimorfisme)");
            CetakPoin("Virtual method: method yang sama berperilaku beda");
            CetakPoin("Interface: IsiBahanBakar() berbeda untuk tiap jenis");

            // 3a. Polymorphism dengan Virtual Method - Klakson
            CetakSubJudul("3a. Klakson berbeda tiap mobil");
            Console.WriteLine("  Mobil Biasa:");
            avanza.Klakson();
            Console.WriteLine("  Mobil Sport:");
            ferrari.Klakson();
            Console.WriteLine("  Mobil Listrik:");
            tesla.Klakson();

            // 3b. Polymorphism - Nyalakan
            CetakSubJudul("3b. Nyalakan mesin berbeda");
            Console.WriteLine("  Mobil Sport (suara mengaum):");
            ferrari.Nyalakan();
            Console.WriteLine("  Mobil Listrik (senyap):");
            tesla.Nyalakan();

            // 3c. Polymorphism - Jalan
            CetakSubJudul("3c. Cara jalan berbeda");
            Console.WriteLine("  Mobil Sport (kencang):");
            ferrari.Jalan();
            Console.WriteLine("  Mobil Sport dengan TURBO:");
            ferrari.AktifkanTurbo();
            ferrari.Jalan();
            Console.WriteLine("  Mobil Listrik (tanpa suara):");
            tesla.Jalan();

            // 3d. Polymorphism - Interface IsiBahanBakar
            CetakSubJudul("3d. IsiBahanBakar() berperilaku BERBEDA");
            Console.WriteLine("  Mobil Biasa (isi bensin):");
            avanza.IsiBahanBakar(20);
            Console.WriteLine("  Mobil Listrik (charge baterai):");
            tesla.IsiBahanBakar(30);

            // 3e. Polymorphism dengan Array tipe kelas induk
            CetakSubJudul("3e. Satu tipe variable, banyak bentuk perilaku");
            Console.WriteLine("  Array bertipe Kendaraan menyimpan berbagai jenis mobil:");
            Console.WriteLine();

            // Array bertipe kelas induk bisa menyimpan objek kelas turunan
            Kendaraan[] semuaKendaraan = { avanza, ferrari, tesla };

            foreach (Kendaraan k in semuaKendaraan)
            {
                Console.WriteLine($"  --- {k.Merk} (tipe: {k.GetType().Name}) ---");
                k.Klakson();
                k.Berhenti();
                Console.WriteLine();
            }

            // ==============================================================
            // BAGIAN 4: ABSTRACTION (Abstraksi)
            // ==============================================================
            CetakJudul("PILAR 4: ABSTRACTION (Abstraksi)");
            CetakPoin("Abstract class Kendaraan tidak bisa dibuat objeknya");
            CetakPoin("Interface IKendaraan & IBisaDiisi menyembunyikan detail");
            CetakPoin("Pengguna hanya perlu tahu 'apa yang bisa dilakukan'");

            // 4a. Abstract class tidak bisa diinstansiasi
            CetakSubJudul("4a. Abstract class tidak bisa dibuat objeknya");
            Console.WriteLine("  // Kendaraan k = new Kendaraan(...); // ERROR!");
            Console.WriteLine("  // Hanya bisa dijadikan 'cetak biru' kelas turunan");

            // 4b. Interface sebagai tipe variable
            CetakSubJudul("4b. Interface sebagai tipe variabel");
            Console.WriteLine("  Menggunakan interface IKendaraan:");
            Console.WriteLine();

            IKendaraan kendaraan1 = avanza;
            IKendaraan kendaraan2 = ferrari;
            IKendaraan kendaraan3 = tesla;

            Console.WriteLine($"  kendaraan1 -> {kendaraan1.GetInfoKendaraan()}");
            Console.WriteLine($"  kendaraan2 -> {kendaraan2.GetInfoKendaraan()}");
            Console.WriteLine($"  kendaraan3 -> {kendaraan3.GetInfoKendaraan()}");

            // 4c. Interface IBisaDiisi
            CetakSubJudul("4c. Interface IBisaDiisi");
            Console.WriteLine("  Interface menyembunyikan detail implementasi:");
            Console.WriteLine();

            IBisaDiisi[] bisaDiisi = { avanza, ferrari, tesla };
            foreach (IBisaDiisi item in bisaDiisi)
            {
                Kendaraan kdr = (Kendaraan)item;
                Console.WriteLine($"  -> {kdr.Merk}: Sisa = {item.CekSisaBahanBakar()}");
            }

            // ==============================================================
            // Matikan semua mesin
            // ==============================================================
            CetakJudul("MATIKAN SEMUA KENDARAAN");
            ferrari.NonaktifkanTurbo();
            ferrari.Matikan();
            tesla.Matikan();

            // ==============================================================
            // Ringkasan
            // ==============================================================
            CetakJudul("RINGKASAN 4 PILAR OOP");
            Console.WriteLine();
            Console.WriteLine("  1. ENCAPSULATION:");
            Console.WriteLine("     - Field private + Property getter/setter");
            Console.WriteLine("     - Validasi data dalam setter");
            Console.WriteLine("     - Access modifier: private, protected, public");
            Console.WriteLine();
            Console.WriteLine("  2. INHERITANCE:");
            Console.WriteLine("     - Kendaraan -> Mobil -> MobilSport/MobilListrik");
            Console.WriteLine("     - Kelas turunan mewarisi property & method induk");
            Console.WriteLine("     - Menggunakan base() untuk constructor induk");
            Console.WriteLine();
            Console.WriteLine("  3. POLYMORPHISM:");
            Console.WriteLine("     - Virtual method: Klakson(), Nyalakan(), Jalan()");
            Console.WriteLine("     - Override: tiap kelas punya perilaku berbeda");
            Console.WriteLine("     - Interface: IsiBahanBakar() -> bensin vs charge");
            Console.WriteLine();
            Console.WriteLine("  4. ABSTRACTION:");
            Console.WriteLine("     - Abstract class Kendaraan");
            Console.WriteLine("     - Abstract method: Jalan(), Berhenti()");
            Console.WriteLine("     - Interface: IKendaraan, IBisaDiisi");
            Console.WriteLine();
            CetakGaris('=');
            Console.WriteLine();
            Console.WriteLine("  Program selesai. Tekan Enter untuk keluar...");
            Console.ReadLine();
        }
    }
}
