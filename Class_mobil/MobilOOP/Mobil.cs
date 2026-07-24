// ============================================================
// PILAR 2: INHERITANCE (Pewarisan)
// Kelas Mobil mewarisi (inherit) dari kelas abstrak Kendaraan.
// Mobil mendapatkan semua property dan method dari Kendaraan,
// serta mengimplementasikan method abstrak yang diwajibkan.
// ============================================================

namespace MobilOOP
{
    /// <summary>
    /// Kelas Mobil - turunan dari Kendaraan (Inheritance).
    /// Mengimplementasikan abstract method dan menambahkan 
    /// property/method khusus untuk mobil.
    /// </summary>
    public class Mobil : Kendaraan
    {
        // ========================================================
        // PILAR 1: ENCAPSULATION (Enkapsulasi)
        // Field private tambahan khusus untuk kelas Mobil
        // ========================================================
        private int _jumlahPintu;
        private string _jenisTransmisi = ""; // "Manual" atau "Otomatis"
        private int _kecepatan;

        // Property dengan validasi (Enkapsulasi)
        public int JumlahPintu
        {
            get { return _jumlahPintu; }
            set
            {
                if (value >= 2 && value <= 6)
                    _jumlahPintu = value;
                else
                    Console.WriteLine("[ERROR] Jumlah pintu harus antara 2-6!");
            }
        }

        public string JenisTransmisi
        {
            get { return _jenisTransmisi; }
            set
            {
                if (value == "Manual" || value == "Otomatis")
                    _jenisTransmisi = value;
                else
                    Console.WriteLine("[ERROR] Transmisi harus 'Manual' atau 'Otomatis'!");
            }
        }

        public int Kecepatan
        {
            get { return _kecepatan; }
            private set { _kecepatan = value; } // hanya bisa diubah dari dalam kelas
        }

        // Constructor - memanggil constructor kelas induk dengan base()
        public Mobil(string merk, int tahunProduksi, string warna, double bahanBakar,
                     int jumlahPintu, string jenisTransmisi)
            : base(merk, tahunProduksi, warna, bahanBakar)
        {
            JumlahPintu = jumlahPintu;
            JenisTransmisi = jenisTransmisi;
            _kecepatan = 0;
        }

        // ========================================================
        // Implementasi ABSTRACT method dari kelas Kendaraan
        // (ABSTRACTION + POLYMORPHISM)
        // ========================================================
        public override void Jalan()
        {
            if (MesinMenyala)
            {
                _kecepatan = 60;
                Console.WriteLine($"  [JALAN] {Merk} melaju dengan kecepatan {_kecepatan} km/jam.");
            }
            else
            {
                Console.WriteLine($"  [JALAN] {Merk} tidak bisa jalan, mesin belum dinyalakan!");
            }
        }

        public override void Berhenti()
        {
            _kecepatan = 0;
            Console.WriteLine($"  [BERHENTI] {Merk} berhenti. Kecepatan: {_kecepatan} km/jam.");
        }

        // ========================================================
        // PILAR 3: POLYMORPHISM - Override virtual method
        // Mengubah perilaku method Klakson() dari kelas induk
        // ========================================================
        public override void Klakson()
        {
            Console.WriteLine($"  [KLAKSON] {Merk}: Tin! Tin! Tin!");
        }

        // Override GetInfoKendaraan untuk menampilkan info lebih lengkap
        public override string GetInfoKendaraan()
        {
            return base.GetInfoKendaraan() +
                   $", Pintu: {_jumlahPintu}, Transmisi: {_jenisTransmisi}" +
                   $", Bahan Bakar: {_bahanBakar} liter";
        }

        // Method tambahan khusus Mobil
        public void Akselerasi(int tambahanKecepatan)
        {
            if (MesinMenyala)
            {
                _kecepatan += tambahanKecepatan;
                if (_kecepatan > 200) _kecepatan = 200;
                Console.WriteLine($"  [AKSELERASI] {Merk} menambah kecepatan menjadi {_kecepatan} km/jam.");
            }
            else
            {
                Console.WriteLine($"  [AKSELERASI] Mesin belum menyala!");
            }
        }
    }
}
