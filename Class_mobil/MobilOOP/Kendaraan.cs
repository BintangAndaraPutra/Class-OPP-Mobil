// ============================================================
// PILAR 4: ABSTRACTION (Abstraksi) - Abstract Class
// Abstract class tidak bisa diinstansiasi secara langsung.
// Berfungsi sebagai "cetak biru" bagi kelas turunannya.
// ============================================================

namespace MobilOOP
{
    /// <summary>
    /// Abstract class Kendaraan - kelas dasar abstrak untuk semua kendaraan.
    /// Menggabungkan konsep abstraksi (abstract method) dan 
    /// menyediakan implementasi umum yang bisa digunakan kelas turunan.
    /// </summary>
    public abstract class Kendaraan : IKendaraan, IBisaDiisi
    {
        // ========================================================
        // PILAR 1: ENCAPSULATION (Enkapsulasi)
        // Field dibuat private agar tidak bisa diakses langsung
        // dari luar kelas. Akses dilakukan melalui Property.
        // ========================================================
        private string _merk = "";
        private int _tahunProduksi;
        private string _warna = "";
        private bool _mesinMenyala;
        protected double _bahanBakar; // protected agar bisa diakses kelas turunan

        // Property dengan getter dan setter (Enkapsulasi)
        // Mengontrol bagaimana data diakses dan dimodifikasi
        public string Merk
        {
            get { return _merk; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _merk = value;
                else
                    Console.WriteLine("[ERROR] Merk tidak boleh kosong!");
            }
        }

        public int TahunProduksi
        {
            get { return _tahunProduksi; }
            set
            {
                if (value >= 1886 && value <= DateTime.Now.Year)
                    _tahunProduksi = value;
                else
                    Console.WriteLine($"[ERROR] Tahun produksi harus antara 1886-{DateTime.Now.Year}!");
            }
        }

        public string Warna
        {
            get { return _warna; }
            set { _warna = value; }
        }

        public bool MesinMenyala
        {
            get { return _mesinMenyala; }
            protected set { _mesinMenyala = value; } // hanya bisa diubah dari dalam kelas/turunan
        }

        // Constructor
        protected Kendaraan(string merk, int tahunProduksi, string warna, double bahanBakar)
        {
            Merk = merk;
            TahunProduksi = tahunProduksi;
            Warna = warna;
            _bahanBakar = bahanBakar;
            _mesinMenyala = false;
        }

        // ========================================================
        // PILAR 3: POLYMORPHISM (Polimorfisme) - Virtual Method
        // Method virtual bisa di-override oleh kelas turunan
        // untuk memberikan perilaku yang berbeda-beda.
        // ========================================================
        public virtual void Nyalakan()
        {
            if (!_mesinMenyala)
            {
                _mesinMenyala = true;
                Console.WriteLine($"  [MESIN] {_merk} dinyalakan. Brum brum...");
            }
            else
            {
                Console.WriteLine($"  [MESIN] {_merk} sudah menyala!");
            }
        }

        public virtual void Matikan()
        {
            if (_mesinMenyala)
            {
                _mesinMenyala = false;
                Console.WriteLine($"  [MESIN] {_merk} dimatikan.");
            }
            else
            {
                Console.WriteLine($"  [MESIN] {_merk} sudah mati!");
            }
        }

        // Virtual method - bisa di-override
        public virtual void Klakson()
        {
            Console.WriteLine("  [KLAKSON] Beep! Beep!");
        }

        // ========================================================
        // PILAR 4: ABSTRACTION - Abstract Method
        // Method abstrak WAJIB diimplementasi oleh kelas turunan.
        // Kelas ini hanya mendeklarasikan "apa", bukan "bagaimana".
        // ========================================================
        public abstract void Jalan();
        public abstract void Berhenti();

        // Implementasi interface IBisaDiisi (virtual agar bisa di-override)
        public virtual void IsiBahanBakar(double jumlah)
        {
            _bahanBakar += jumlah;
            Console.WriteLine($"  [BAHAN BAKAR] Mengisi {jumlah} liter. Total: {_bahanBakar} liter.");
        }

        public double CekSisaBahanBakar()
        {
            return _bahanBakar;
        }

        // Implementasi interface IKendaraan
        public virtual string GetInfoKendaraan()
        {
            return $"Merk: {_merk}, Tahun: {_tahunProduksi}, Warna: {_warna}";
        }
    }
}
