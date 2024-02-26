using System;
using System.Collections.Generic;

public class Program
{
    private static List<Employee> employees = new List<Employee>();

    // Metode utama
    static void Main(string[] args)
    {
        //Memasukkan data awal
        Employee emp1 = new Employee { EmployeeId = "1001", FullName = "Adit", BirthDate = new DateTime(1954, 8, 17) };
        Employee emp2 = new Employee { EmployeeId = "1002", FullName = "Anton", BirthDate = new DateTime(1954, 8, 18) };
        Employee emp3 = new Employee { EmployeeId = "1003", FullName = "Amir", BirthDate = new DateTime(1954, 8, 19) };

        employees.Add(emp1);
        employees.Add(emp2);
        employees.Add(emp3);

        TampilData();

        while (true)
        {

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Tambah Data");
            Console.WriteLine("2. Tampilkan Data");
            Console.WriteLine("3. Hapus Data");
            Console.WriteLine("4. Keluar");
            Console.Write("Pilih menu: ");

            string opt = Console.ReadLine() ?? "";

            switch (opt)
            {
                case "1":
                    TambahKaryawan();
                    break;
                case "2":
                    TampilData();
                    break;
                case "3":
                    HapusData();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid");
                    break;
            }
        }
    }
    // Menambahkan data karyawan
    static void TambahKaryawan()
    {
        // Meminta input Employee ID dari pengguna
        Console.WriteLine("Input Employee ID:");
        string employeeId = Console.ReadLine() ?? "";

        // Jika Employee ID tidak diisi, tampilkan pesan error dan minta input kembali
        while (string.IsNullOrEmpty(employeeId.Trim()))
        {
            Console.WriteLine("EmployeeID harus diisi");
            employeeId = Console.ReadLine() ?? "";
        }

        // Meminta input FullName dari pengguna
        Console.WriteLine("Input FullName:");
        string fullName = Console.ReadLine() ?? "";

        // Jika FullName tidak diisi, tampilkan pesan error dan minta input kembali
        while (string.IsNullOrEmpty(fullName.Trim()))
        {
            Console.WriteLine("FullName harus diisi");
            fullName = Console.ReadLine() ?? "";
        }

        DateTime birthDate;
        while (true)
        {
            Console.WriteLine("Input BirthDate (dd/mm/yyyy):");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out birthDate))
                break;
            else
                Console.WriteLine("Format tanggal salah (dd/mm/yyyy)");
        }

        // Cek data duplikat
        if (employees.Any(e => e.EmployeeId == employeeId))
        {
            Console.WriteLine("Employee ID sudah ada. Gunakan ID yang berbeda.");
        }
        else
        {
            employees.Add(new Employee { EmployeeId = employeeId.Trim(), FullName = fullName.Trim(), BirthDate = birthDate });
            Console.WriteLine("Data karyawan berhasil ditambahkan");
        }
    }

    // Menampilkan list data karyawan
    static void TampilData()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("| EmployeeId | Full Name | Birth Date  |");
        Console.WriteLine("----------------------------------------");

        foreach (var employee in employees)
        {
            Console.WriteLine($"| {employee.EmployeeId,-10} | {employee.FullName,-9} | {employee.BirthDate.ToString("dd-MMM-yyyy"),-11} |");
        }
        Console.WriteLine("----------------------------------------");
    }

    // Menghapus data karyawan berdasarkan EmployeeId
    static void HapusData()
    {
        Console.WriteLine("Masukkan EmployeeId untuk menghapus: ");
        string employeeId = Console.ReadLine() ?? "";

        var employeeToRemove = employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        if (employeeToRemove != null)
        {
            employees.Remove(employeeToRemove);
            Console.WriteLine("Data karyawan berhasil dihapus");
        }
        else
        {
            Console.WriteLine("Data karyawan tidak ditemukan");
        }
    }
}
public class Employee
{
    public string? EmployeeId { get; set; }
    public string? FullName { get; set; }
    public DateTime BirthDate { get; set; }
}