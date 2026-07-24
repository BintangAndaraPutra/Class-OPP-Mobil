// ============================================================
// PILAR 2: INHERITANCE (Pewarisan) - Multi-level Inheritance
// MobilSport mewarisi dari Mobil, yang mewarisi dari Kendaraan.
// Ini menunjukkan inheritance bertingkat (multi-level).
//
// PILAR 3: POLYMORPHISM (Polimorfisme)
// MobilSport meng-override method-method untuk perilaku berbeda.
// ============================================================

namespace MobilOOP
{
    /// <summary>
    /// Kelas MobilSport - turunan dari Mobil (multi-level inheritance).
    /// Memiliki fitur tambahan seperti mode turbo.
    /// </summary>
    public class MobilSport : Mobil
    {
        // Encapsulation - field private
        private bool _turboAktif;
        private int _tenagaHP;

        public bool TurboAktif
        {
            get { return _turboAktif; }
            private set { _turboAktif = value; }
        }

        public int TenagaHP
        {
            get { return _tenagaHP; }
            set
            {
                if (value > 0)
                    _tenagaHP = value;
                else
                    Console.WriteLine("[ERROR] Tenaga HP harus lebih dari 0!");
            }
        }

        // Constructor
        public MobilSport(string merk, int tahunProduksi, string warna, double bahanBakar,
                          int jumlahPintu, string jenisTransmisi, int tenagaHP)
            : base(merk, tahunProduksi, warna, bahanBakar, jumlahPintu, jenisTransmisi)
        {
            TenagaHP = tenagaHP;
            _turboAktif = false;
        }

        // ========================================================
        // POLYMORPHISM - Override method untuk perilaku berbeda
        // ========================================================
        public override void Nyalakan()
        {
            base.Nyalakan(); // memanggil method induk
            if (MesinMenyala)
                Console.WriteLine($"  [SPORT] Suara mesin {Merk} mengaum! VROOOOM! ({_tenagaHP} HP)");
        }

        public override void Jalan()
        {
            if (MesinMenyala)
            {
                int kecepatan = _turboAktif ? 150 : 100;
                Console.WriteLine($"  [JALAN] {Merk} melesat dengan kecepatan {kecepatan} km/jam!" +
                                  (_turboAktif ? " [TURBO ON]" : ""));
            }
            else
            {
                Console.WriteLine($"  [JALAN] {Merk} tidak bisa jalan, mesin belum dinyalakan!");
            }
        }

        public override void Berhenti()
        {
            if (_turboAktif) _turboAktif = false;
            Console.WriteLine($"  [BERHENTI] {Merk} berhenti dengan rem cakram performa tinggi.");
        }

        public override void Klakson()
        {
            Console.WriteLine($"  [KLAKSON] {Merk}: PAAARP! PAAARP! (klakson sport)");
        }

        public override string GetInfoKendaraan()
        {
            return base.GetInfoKendaraan() +
                   $", Tenaga: {_tenagaHP} HP, Turbo: {(_turboAktif ? "Aktif" : "Nonaktif")}";
        }

        // Method khusus MobilSport
        public void AktifkanTurbo()
        {
            if (MesinMenyala)
            {
                _turboAktif = true;
                Console.WriteLine($"  [TURBO] {Merk}: Turbo DIAKTIFKAN! Tenaga maksimal!");
            }
            else
            {
                Console.WriteLine($"  [TURBO] Mesin belum menyala, tidak bisa aktifkan turbo!");
            }
        }

        public void NonaktifkanTurbo()
        {
            _turboAktif = false;
            Console.WriteLine($"  [TURBO] {Merk}: Turbo dinonaktifkan.");
        }
    }
}
