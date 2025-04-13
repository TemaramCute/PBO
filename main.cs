using System;

namespace ManajemenKaryawan
{
    // Kelas induk
    class Karyawan
    {
        // Atribut private
        private string nama;
        private string id;
        private double gajiPokok;

        // Getter dan Setter
        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public double GajiPokok
        {
            get { return gajiPokok; }
            set { gajiPokok = value; }
        }

        // Konstruktor
        public Karyawan(string nama, string id, double gajiPokok)
        {
            this.nama = nama;
            this.id = id;
            this.gajiPokok = gajiPokok;
        }

        // Method virtual untuk dihitung ulang di kelas turunan
        public virtual double HitungGaji()
        {
            return gajiPokok;
        }
    }

    // Karyawan Tetap
    class KaryawanTetap : Karyawan
    {
        private double bonusTetap = 500000;

        public KaryawanTetap(string nama, string id, double gajiPokok)
            : base(nama, id, gajiPokok) { }

        public override double HitungGaji()
        {
            return GajiPokok + bonusTetap;
        }
    }

    // Karyawan Kontrak
    class KaryawanKontrak : Karyawan
    {
        private double potonganKontrak = 200000;

        public KaryawanKontrak(string nama, string id, double gajiPokok)
            : base(nama, id, gajiPokok) { }

        public override double HitungGaji()
        {
            return GajiPokok - potonganKontrak;
        }
    }

    // Karyawan Magang
    class KaryawanMagang : Karyawan
    {
        public KaryawanMagang(string nama, string id, double gajiPokok)
            : base(nama, id, gajiPokok) { }

        public override double HitungGaji()
        {
            return GajiPokok; // Tidak ada bonus atau potongan
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistem Manajemen Karyawan ===");
            Console.Write("Masukkan jenis karyawan (Tetap/Kontrak/Magang): ");
            string jenis = Console.ReadLine().ToLower();

            Console.Write("Nama: ");
            string nama = Console.ReadLine();

            Console.Write("ID: ");
            string id = Console.ReadLine();

            Console.Write("Gaji Pokok: ");
            double gajiPokok = Convert.ToDouble(Console.ReadLine());

            Karyawan karyawan;

            switch (jenis)
            {
                case "tetap":
                    karyawan = new KaryawanTetap(nama, id, gajiPokok);
                    break;
                case "kontrak":
                    karyawan = new KaryawanKontrak(nama, id, gajiPokok);
                    break;
                case "magang":
                    karyawan = new KaryawanMagang(nama, id, gajiPokok);
                    break;
                default:
                    Console.WriteLine("Jenis karyawan tidak dikenali.");
                    return;
            }

            Console.WriteLine($"\n==== Data Karyawan ====");
            Console.WriteLine($"Nama: {karyawan.Nama}");
            Console.WriteLine($"ID: {karyawan.ID}");
            Console.WriteLine($"Gaji Akhir: {karyawan.HitungGaji()}");
        }
    }
}