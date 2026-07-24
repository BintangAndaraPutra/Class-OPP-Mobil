// ============================================================
// PILAR 2: INHERITANCE - MobilListrik mewarisi dari Mobil
// PILAR 3: POLYMORPHISM - Override method + implementasi Interface
// PILAR 4: ABSTRACTION - Mengimplementasi interface IBisaDiisi
//          dengan cara yang BERBEDA (mengisi daya, bukan bensin)
// ============================================================

namespace MobilOOP
{
    /// <summary>
    /// Kelas MobilListrik - turunan dari Mobil.
    /// Mendemonstrasikan polymorphism karena method yang sama
    /// (IsiBahanBakar) berperilaku berbeda di kelas ini.
    /// </summary>
    public class MobilListrik : Mobil
    {
        // Encapsulation
        private double _kapasitasBaterai; // dalam kWh
        private double _dayaBaterai;      // sisa daya dalam kWh

        public double KapasitasBaterai
        {
            get { return _kapasitasBaterai; }
            set
            {
                if (value > 0)
                    _kapasitasBaterai = value;
                else
                    Console.WriteLine("[ERROR] Kapasitas baterai harus lebih dari 0!");
            }
        }

        public double DayaBaterai
        {
            get { return _dayaBaterai; }
            private set { _dayaBaterai = value; }
        }

        // Constructor
        public MobilListrik(string merk, int tahunProduksi, string warna,
                            int jumlahPintu, string jenisTransmisi,
                            double kapasitasBaterai, double dayaBaterai)
            : base(merk, tahunProduksi, warna, 0, jumlahPintu, jenisTransmisi)
        {
            KapasitasBaterai = kapasitasBaterai;
            _dayaBaterai = dayaBaterai;
        }

        // ========================================================
        // POLYMORPHISM - Override method untuk perilaku berbeda
        // Mobil listrik punya perilaku yang berbeda dari mobil biasa
        // ========================================================
        public override void Nyalakan()
        {
            if (!MesinMenyala)
            {
                if (_dayaBaterai > 0)
                {
                    MesinMenyala = true;
                    Console.WriteLine($"  [MESIN] {Merk} dinyalakan secara SENYAP. Hmmmmm...");
                    Console.WriteLine($"  [BATERAI] Sisa daya: {_dayaBaterai}/{_kapasitasBaterai} kWh");
                }
                else
                {
                    Console.WriteLine($"  [MESIN] {Merk} tidak bisa dinyalakan, baterai habis!");
                }
            }
            else
            {
                Console.WriteLine($"  [MESIN] {Merk} sudah menyala!");
            }
        }

        public override void Jalan()
        {
            if (MesinMenyala && _dayaBaterai > 0)
            {
                _dayaBaterai -= 5; // mengurangi daya baterai
                if (_dayaBaterai < 0) _dayaBaterai = 0;
                Console.WriteLine($"  [JALAN] {Merk} melaju TANPA SUARA dengan kecepatan 80 km/jam.");
                Console.WriteLine($"  [BATERAI] Sisa daya: {_dayaBaterai}/{_kapasitasBaterai} kWh");
            }
            else if (!MesinMenyala)
            {
                Console.WriteLine($"  [JALAN] {Merk} tidak bisa jalan, mesin belum dinyalakan!");
            }
            else
            {
                Console.WriteLine($"  [JALAN] {Merk} baterai habis! Perlu di-charge!");
                MesinMenyala = false;
            }
        }

        public override void Berhenti()
        {
            Console.WriteLine($"  [BERHENTI] {Merk} berhenti dengan regenerative braking.");
            _dayaBaterai += 1; // sedikit mengisi ulang saat pengereman
            if (_dayaBaterai > _kapasitasBaterai)
                _dayaBaterai = _kapasitasBaterai;
            Console.WriteLine($"  [BATERAI] Daya terisi sedikit dari pengereman: {_dayaBaterai} kWh");
        }

        public override void Klakson()
        {
            Console.WriteLine($"  [KLAKSON] {Merk}: Piip~ Piip~ (klakson futuristik)");
        }

        // ========================================================
        // POLYMORPHISM pada Interface
        // Method IsiBahanBakar() di-override dengan perilaku BERBEDA.
        // Mobil listrik tidak pakai bensin, tapi CHARGE baterai.
        // Ini adalah contoh nyata polymorphism.
        // ========================================================
        public override void IsiBahanBakar(double jumlah)
        {
            // Perilaku BERBEDA dari mobil biasa - ini adalah CHARGING
            _dayaBaterai += jumlah;
            if (_dayaBaterai > _kapasitasBaterai)
                _dayaBaterai = _kapasitasBaterai;
            Console.WriteLine($"  [CHARGE] {Merk} di-charge {jumlah} kWh. Daya: {_dayaBaterai}/{_kapasitasBaterai} kWh");
        }

        public override string GetInfoKendaraan()
        {
            return $"Merk: {Merk}, Tahun: {TahunProduksi}, Warna: {Warna}" +
                   $", Pintu: {JumlahPintu}, Transmisi: {JenisTransmisi}" +
                   $", Baterai: {_dayaBaterai}/{_kapasitasBaterai} kWh [LISTRIK]";
        }

        // Method khusus MobilListrik
        public void CekStatusBaterai()
        {
            double persen = (_dayaBaterai / _kapasitasBaterai) * 100;
            Console.WriteLine($"  [STATUS] Baterai {Merk}: {_dayaBaterai}/{_kapasitasBaterai} kWh ({persen:F1}%)");
            if (persen < 20)
                Console.WriteLine("  [PERINGATAN] Baterai rendah! Segera isi daya!");
        }
    }
}
