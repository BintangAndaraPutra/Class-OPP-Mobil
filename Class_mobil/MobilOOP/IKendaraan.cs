// ============================================================
// PILAR 4: ABSTRACTION (Abstraksi) - Interface
// Interface menyembunyikan detail implementasi dan hanya
// menampilkan "apa yang bisa dilakukan" tanpa "bagaimana caranya"
// ============================================================

namespace MobilOOP
{
    /// <summary>
    /// Interface IKendaraan - kontrak dasar untuk semua kendaraan.
    /// Semua kelas yang mengimplementasi interface ini WAJIB
    /// menyediakan implementasi method-method berikut.
    /// </summary>
    public interface IKendaraan
    {
        void Nyalakan();
        void Matikan();
        string GetInfoKendaraan();
    }

    /// <summary>
    /// Interface IBisaDiisi - kontrak untuk kendaraan yang bisa diisi bahan bakar/energi.
    /// Menunjukkan bahwa satu kelas bisa mengimplementasi banyak interface.
    /// </summary>
    public interface IBisaDiisi
    {
        void IsiBahanBakar(double jumlah);
        double CekSisaBahanBakar();
    }
}
