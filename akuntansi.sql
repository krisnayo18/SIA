-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jun 21, 2019 at 07:12 PM
-- Server version: 5.5.32
-- PHP Version: 5.4.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `akuntansi`
--
CREATE DATABASE IF NOT EXISTS `akuntansi` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `akuntansi`;

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE IF NOT EXISTS `barang` (
  `kodeBarang` varchar(5) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `jenis` enum('BB','BJ','BP') DEFAULT NULL,
  `hargaBeliTerbaru` int(11) DEFAULT NULL,
  `hargaJual` int(11) DEFAULT NULL,
  `satuan` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`kodeBarang`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`kodeBarang`, `nama`, `quantity`, `jenis`, `hargaBeliTerbaru`, `hargaJual`, `satuan`) VALUES
('BB001', 'Bijih Plastik', 214, 'BB', 8000, 5000, 'kg'),
('BB002', 'Pewarna', 890, 'BB', 7000, 1000, 'botol'),
('BJ001', 'Sapu', 18, 'BJ', 9000, 50000, 'buah'),
('BJ002', 'Ember', 27, 'BJ', 10000, 40000, 'buah');

-- --------------------------------------------------------

--
-- Table structure for table `detiljoborder`
--

CREATE TABLE IF NOT EXISTS `detiljoborder` (
  `kodeJobOrder` varchar(10) NOT NULL,
  `idKaryawan` int(11) NOT NULL,
  `satuan` enum('Unit','Jam') DEFAULT NULL,
  `gajiPerSatuan` int(11) DEFAULT NULL,
  PRIMARY KEY (`kodeJobOrder`,`idKaryawan`),
  KEY `fk_JobOrder_has_karyawan_karyawan1_idx` (`idKaryawan`),
  KEY `fk_JobOrder_has_karyawan_JobOrder1_idx` (`kodeJobOrder`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `detilnotabeli`
--

CREATE TABLE IF NOT EXISTS `detilnotabeli` (
  `noNotaPembelian` varchar(12) NOT NULL,
  `kodeBarang` varchar(5) NOT NULL,
  `jumlah` int(11) DEFAULT NULL,
  `hargaBeli` int(11) DEFAULT NULL,
  PRIMARY KEY (`noNotaPembelian`,`kodeBarang`),
  KEY `fk_NotaPembelian_has_Barang_Barang1_idx` (`kodeBarang`),
  KEY `fk_NotaPembelian_has_Barang_NotaPembelian_idx` (`noNotaPembelian`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `detilnotajual`
--

CREATE TABLE IF NOT EXISTS `detilnotajual` (
  `noNotaPenjualan` varchar(12) NOT NULL,
  `kodeBarang` varchar(5) NOT NULL,
  `jumlah` int(11) DEFAULT NULL,
  `hargaJual` int(11) DEFAULT NULL,
  PRIMARY KEY (`noNotaPenjualan`,`kodeBarang`),
  KEY `fk_NotaPenjualan_has_Barang_Barang1_idx` (`kodeBarang`),
  KEY `fk_NotaPenjualan_has_Barang_NotaPenjualan1_idx` (`noNotaPenjualan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `detilsuratjalan`
--

CREATE TABLE IF NOT EXISTS `detilsuratjalan` (
  `noSuratJalan` varchar(12) NOT NULL,
  `kodeBarang` varchar(5) NOT NULL,
  `jumlah` int(11) DEFAULT NULL,
  PRIMARY KEY (`noSuratJalan`,`kodeBarang`),
  KEY `fk_suratJalan_has_Barang_Barang1_idx` (`kodeBarang`),
  KEY `fk_suratJalan_has_Barang_suratJalan1_idx` (`noSuratJalan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `detilsuratpermintaan`
--

CREATE TABLE IF NOT EXISTS `detilsuratpermintaan` (
  `kodeBarang` varchar(5) NOT NULL,
  `noSuratPermintaan` varchar(12) NOT NULL,
  `jumlah` int(11) DEFAULT NULL,
  PRIMARY KEY (`kodeBarang`,`noSuratPermintaan`),
  KEY `fk_Barang_has_suratPermintaan_suratPermintaan1_idx` (`noSuratPermintaan`),
  KEY `fk_Barang_has_suratPermintaan_Barang1_idx` (`kodeBarang`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `ekspedisi`
--

CREATE TABLE IF NOT EXISTS `ekspedisi` (
  `idEkspedisi` varchar(12) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `alamat` varchar(225) DEFAULT NULL,
  `noTelepon` varchar(12) DEFAULT NULL,
  `harga` int(11) DEFAULT NULL,
  PRIMARY KEY (`idEkspedisi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ekspedisi`
--

INSERT INTO `ekspedisi` (`idEkspedisi`, `nama`, `alamat`, `noTelepon`, `harga`) VALUES
('E001', 'JNE', 'Kaliwaru', '081280154142', 9000),
('E002', 'JNT', 'Kaliwaru', '081280154142', 10000);

-- --------------------------------------------------------

--
-- Table structure for table `joborder`
--

CREATE TABLE IF NOT EXISTS `joborder` (
  `kodeJobOrder` varchar(10) NOT NULL,
  `quantity` int(11) DEFAULT NULL,
  `directLabor` int(11) DEFAULT NULL,
  `directMaterial` int(11) DEFAULT NULL,
  `overheadProduksi` int(11) DEFAULT NULL,
  `tglMulai` datetime DEFAULT NULL,
  `tglSelesai` datetime DEFAULT NULL,
  `kodeBarang` varchar(5) NOT NULL,
  `noNotaPenjualan` varchar(12) NOT NULL,
  `status` enum('P','S') DEFAULT NULL,
  PRIMARY KEY (`kodeJobOrder`),
  KEY `fk_JobOrder_Barang1_idx` (`kodeBarang`),
  KEY `fk_JobOrder_NotaPenjualan1_idx` (`noNotaPenjualan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `karyawan`
--

CREATE TABLE IF NOT EXISTS `karyawan` (
  `idKaryawan` int(11) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `gender` enum('L','P') DEFAULT NULL,
  `alamat` varchar(225) DEFAULT NULL,
  `noTelepon` varchar(12) DEFAULT NULL,
  `gaji` int(11) DEFAULT NULL,
  PRIMARY KEY (`idKaryawan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `karyawan`
--

INSERT INTO `karyawan` (`idKaryawan`, `nama`, `gender`, `alamat`, `noTelepon`, `gaji`) VALUES
(1, 'Krisna Yoga', 'L', 'Balongbendo', '081280154142', 10000),
(2, 'Zubaids', 'L', 'Trenggalek', '081280154343', 10000000),
(3, 'Sigit Permana E.', 'L', 'Sidoarjo', '08128072423', 10000000),
(4, 'Hanif', 'L', 'Sidoarjo', '089189127273', 10000000);

-- --------------------------------------------------------

--
-- Table structure for table `notapembelian`
--

CREATE TABLE IF NOT EXISTS `notapembelian` (
  `noNotaPembelian` varchar(12) NOT NULL,
  `diskon` double DEFAULT NULL,
  `totalHarga` int(11) DEFAULT NULL,
  `tglBatasPelunasan` datetime DEFAULT NULL,
  `tglBatasDiskon` datetime DEFAULT NULL,
  `tglBeli` datetime DEFAULT NULL,
  `status` enum('L','P','B') DEFAULT NULL,
  `keterangan` varchar(225) DEFAULT NULL,
  `idSupplier` int(11) NOT NULL,
  PRIMARY KEY (`noNotaPembelian`),
  KEY `fk_NotaPembelian_supplier1_idx` (`idSupplier`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `notapenjualan`
--

CREATE TABLE IF NOT EXISTS `notapenjualan` (
  `noNotaPenjualan` varchar(12) NOT NULL,
  `diskon` double DEFAULT NULL,
  `totalHarga` int(11) DEFAULT NULL,
  `tglBatasPelunasan` datetime DEFAULT NULL,
  `tglBatasDiskon` datetime DEFAULT NULL,
  `tglJual` datetime DEFAULT NULL,
  `status` enum('L','P') DEFAULT NULL,
  `keterangan` varchar(225) DEFAULT NULL,
  `idPelanggan` int(11) NOT NULL,
  PRIMARY KEY (`noNotaPenjualan`),
  KEY `fk_NotaPenjualan_Pelanggan1_idx` (`idPelanggan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `pelanggan`
--

CREATE TABLE IF NOT EXISTS `pelanggan` (
  `idPelanggan` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(45) DEFAULT NULL,
  `alamat` varchar(45) DEFAULT NULL,
  `telepon` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idPelanggan`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `pelanggan`
--

INSERT INTO `pelanggan` (`idPelanggan`, `nama`, `alamat`, `telepon`) VALUES
(1, 'Toko Laris', 'Surabaya', '081280231232'),
(2, 'Toko Serba Serbi', 'Sidoarjo', '081234543232');

-- --------------------------------------------------------

--
-- Table structure for table `pelunasan`
--

CREATE TABLE IF NOT EXISTS `pelunasan` (
  `noPelunasan` varchar(12) NOT NULL,
  `tgl` datetime DEFAULT NULL,
  `caraPembayaran` enum('T','K') DEFAULT NULL,
  `nominal` int(11) DEFAULT NULL,
  `noNotaPenjualan` varchar(12) NOT NULL,
  PRIMARY KEY (`noPelunasan`),
  KEY `fk_Pelunasan_NotaPenjualan1_idx` (`noNotaPenjualan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `pembayaran`
--

CREATE TABLE IF NOT EXISTS `pembayaran` (
  `idPembayaran` varchar(12) NOT NULL,
  `tgl` datetime DEFAULT NULL,
  `caraPembayaran` enum('T','K') DEFAULT NULL,
  `nominal` int(11) DEFAULT NULL,
  `noNotaPembelian` varchar(12) NOT NULL,
  PRIMARY KEY (`idPembayaran`),
  KEY `fk_pembayaran_NotaPembelian1_idx` (`noNotaPembelian`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `penerimaan`
--

CREATE TABLE IF NOT EXISTS `penerimaan` (
  `kodePenerimaan` varchar(12) NOT NULL,
  `jenisPengiriman` enum('SP','DP') DEFAULT NULL,
  `biayaKirim` int(11) DEFAULT NULL,
  `tglTerima` datetime DEFAULT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `keterangan` varchar(225) DEFAULT NULL,
  `noNotaPembelian` varchar(12) NOT NULL,
  PRIMARY KEY (`kodePenerimaan`),
  KEY `fk_penerimaan_NotaPembelian1_idx` (`noNotaPembelian`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `pengiriman`
--

CREATE TABLE IF NOT EXISTS `pengiriman` (
  `kodePengiriman` varchar(12) NOT NULL,
  `jenisPengiriman` enum('SP','DP') DEFAULT NULL,
  `biayaKirim` int(11) DEFAULT NULL,
  `tglKirim` datetime DEFAULT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `keterangan` varchar(225) DEFAULT NULL,
  `noNotaPenjualan` varchar(12) NOT NULL,
  `idEkspedisi` varchar(12) NOT NULL,
  PRIMARY KEY (`kodePengiriman`),
  KEY `fk_pengiriman_NotaPenjualan1_idx` (`noNotaPenjualan`),
  KEY `fk_pengiriman_ekspedisi1_idx` (`idEkspedisi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE IF NOT EXISTS `supplier` (
  `idSupplier` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(45) DEFAULT NULL,
  `alamat` varchar(225) DEFAULT NULL,
  `noTelepon` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`idSupplier`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`idSupplier`, `nama`, `alamat`, `noTelepon`) VALUES
(1, 'CV Plastik Utama', 'Sidoarjo', '081237277362'),
(2, 'CV Warna Pelangi', 'Mojokerto', '089123435432');

-- --------------------------------------------------------

--
-- Table structure for table `suratjalan`
--

CREATE TABLE IF NOT EXISTS `suratjalan` (
  `noSuratJalan` varchar(12) NOT NULL,
  `jenis` enum('M','K') DEFAULT NULL,
  `tgl` datetime DEFAULT NULL,
  `keterangan` varchar(225) DEFAULT NULL,
  `noSuratPermintaan` varchar(12) NOT NULL,
  PRIMARY KEY (`noSuratJalan`),
  KEY `fk_suratJalan_suratPermintaan1_idx` (`noSuratPermintaan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `suratpermintaan`
--

CREATE TABLE IF NOT EXISTS `suratpermintaan` (
  `noSuratPermintaan` varchar(12) NOT NULL,
  `tanggal` datetime DEFAULT NULL,
  `keterangan` varchar(45) DEFAULT NULL,
  `kodeJobOrder` varchar(10) NOT NULL,
  PRIMARY KEY (`noSuratPermintaan`),
  KEY `fk_suratPermintaan_JobOrder1_idx` (`kodeJobOrder`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Stand-in structure for view `vlaporandaftarjurnal`
--
CREATE TABLE IF NOT EXISTS `vlaporandaftarjurnal` (
`idjurnal` int(11)
,`tanggal` datetime
,`keterangan` varchar(225)
,`nama` varchar(45)
,`debet` int(11)
,`kredit` int(11)
,`nomorBukti` varchar(12)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `vnotapembelian`
--
CREATE TABLE IF NOT EXISTS `vnotapembelian` (
`noNotaPembelian` varchar(12)
,`idSupplier` int(11)
,`NamaSupplier` varchar(45)
,`Alamatsupplier` varchar(225)
,`diskon` double
,`totalHarga` int(11)
,`tglBatasPelunasan` datetime
,`tglBatasDiskon` datetime
,`tglbeli` datetime
,`status` enum('L','P','B')
,`keterangan` varchar(225)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `vnotapenjualan`
--
CREATE TABLE IF NOT EXISTS `vnotapenjualan` (
`noNotaPenjualan` varchar(12)
,`idPelanggan` int(11)
,`NamaPelanggan` varchar(45)
,`AlamatPelanggan` varchar(45)
,`diskon` double
,`totalHarga` int(11)
,`tglBatasPelunasan` datetime
,`tglBatasDiskon` datetime
,`tglJual` datetime
,`status` enum('L','P')
,`keterangan` varchar(225)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `vsaldoakhir`
--
CREATE TABLE IF NOT EXISTS `vsaldoakhir` (
`kelompok` enum('A','K','E','P','B')
,`nomor` varchar(3)
,`nama` varchar(45)
,`SaldoAkhir` decimal(44,0)
);
-- --------------------------------------------------------

--
-- Table structure for table `_akun`
--

CREATE TABLE IF NOT EXISTS `_akun` (
  `nomor` varchar(3) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `kelompok` enum('A','K','E','P','B') DEFAULT NULL,
  `saldoNormal` int(11) DEFAULT NULL,
  PRIMARY KEY (`nomor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `_akun`
--

INSERT INTO `_akun` (`nomor`, `nama`, `kelompok`, `saldoNormal`) VALUES
('00', 'Ihtisar Laba Rugi', NULL, -1),
('11', 'Kas', 'A', 1),
('12', 'Piutang', 'A', 1),
('13', 'Sediaan Bahan Baku', 'A', 1),
('14', 'WIP', 'A', 1),
('15', 'Sediaan Barang Jadi', 'A', 1),
('21', 'Hutang', 'K', -1),
('22', 'Hutang Gaji', 'K', -1),
('31', 'Modal', 'E', -1),
('41', 'Penjualan', 'P', -1),
('42', 'Retur Penjualan & Penyesuaian Harga', 'P', 1),
('43', 'Diskon Penjualan', 'P', 1),
('51', 'HPP', 'B', 1),
('52', 'Biaya Gaji', 'B', 1),
('53', 'Biaya Transportasi', 'B', 1);

-- --------------------------------------------------------

--
-- Table structure for table `_detiljurnal`
--

CREATE TABLE IF NOT EXISTS `_detiljurnal` (
  `idJurnal` int(11) NOT NULL,
  `nomor` varchar(3) NOT NULL,
  `noUrut` int(11) DEFAULT NULL,
  `debet` int(11) DEFAULT NULL,
  `kredit` int(11) DEFAULT NULL,
  PRIMARY KEY (`idJurnal`,`nomor`),
  KEY `fk__jurnal_has__akun__akun1_idx` (`nomor`),
  KEY `fk__detilJurnal__jurnal1_idx` (`idJurnal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `_detiljurnal`
--

INSERT INTO `_detiljurnal` (`idJurnal`, `nomor`, `noUrut`, `debet`, `kredit`) VALUES
(1, '13', 1, 6000000, 0),
(1, '21', 2, 0, 6000000),
(2, '13', 1, 400000, 0),
(2, '21', 2, 0, 400000),
(3, '13', 2, 0, 5600000),
(3, '14', 1, 5600000, 0),
(4, '14', 1, 14400000, 0),
(4, '22', 2, 0, 14400000),
(5, '11', 2, 0, 14400000),
(5, '22', 1, 14400000, 0),
(6, '14', 2, 0, 20000000),
(6, '15', 1, 20000000, 0),
(7, '11', 1, 8000000, 0),
(7, '15', 4, 0, 4000000),
(7, '41', 2, 0, 8000000),
(7, '51', 3, 4000000, 0),
(8, '11', 2, 0, 392000),
(8, '13', 3, 0, 8000),
(8, '21', 1, 400000, 0);

-- --------------------------------------------------------

--
-- Table structure for table `_jurnal`
--

CREATE TABLE IF NOT EXISTS `_jurnal` (
  `idJurnal` int(11) NOT NULL,
  `tanggal` datetime DEFAULT NULL,
  `nomorBukti` varchar(12) DEFAULT NULL,
  `jenis` enum('JU','JK','JP','JT') DEFAULT NULL,
  `idPeriode` varchar(6) NOT NULL,
  `idTransaksi` varchar(3) NOT NULL,
  PRIMARY KEY (`idJurnal`),
  KEY `fk__jurnal_periode1_idx` (`idPeriode`),
  KEY `fk__jurnal__transaksi1_idx` (`idTransaksi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `_jurnal`
--

INSERT INTO `_jurnal` (`idJurnal`, `tanggal`, `nomorBukti`, `jenis`, `idPeriode`, `idTransaksi`) VALUES
(1, '2015-02-01 15:00:00', '', 'JU', '1502', '001'),
(2, '2015-02-02 10:50:01', '', 'JU', '1502', '002'),
(3, '2015-02-07 09:00:02', '', 'JU', '1502', '004'),
(4, '2015-02-10 15:00:03', '', 'JU', '1502', '005'),
(5, '2015-02-10 11:00:04', '', 'JU', '1502', '006'),
(6, '2015-02-11 12:00:05', '', 'JU', '1502', '007'),
(7, '2015-02-12 15:00:06', '', 'JU', '1502', '008'),
(8, '2015-02-13 10:30:07', '', 'JU', '1502', '009');

-- --------------------------------------------------------

--
-- Table structure for table `_laporan`
--

CREATE TABLE IF NOT EXISTS `_laporan` (
  `idLaporan` varchar(5) NOT NULL,
  `judul` varchar(225) DEFAULT NULL,
  `idPeriode` varchar(6) NOT NULL,
  PRIMARY KEY (`idLaporan`),
  KEY `fk__laporan__periode1_idx` (`idPeriode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `_laporan`
--

INSERT INTO `_laporan` (`idLaporan`, `judul`, `idPeriode`) VALUES
('L1501', 'Laporan Laba Rugi PT Bagoes Banget', '1501'),
('L1502', 'Laporan Laba Rugi PT Bagoes Sekali', '1502'),
('N1501', 'Laporan Neraca PT Bagoes Banget', '1501'),
('N1502', 'Laporan Neraca CV Bagoes Banget', '1502'),
('P1501', 'Laporan Perubahan Ekuitas PT Bagoes Banget', '1501'),
('P1502', 'Laporan Perubahan Ekuitas CV Bagoes Banget', '1502');

-- --------------------------------------------------------

--
-- Table structure for table `_laporanakun`
--

CREATE TABLE IF NOT EXISTS `_laporanakun` (
  `nomor` varchar(3) NOT NULL,
  `idLaporan` varchar(5) NOT NULL,
  PRIMARY KEY (`nomor`,`idLaporan`),
  KEY `fk__akun_has__laporan__laporan1_idx` (`idLaporan`),
  KEY `fk__akun_has__laporan__akun1_idx` (`nomor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `_laporanakun`
--

INSERT INTO `_laporanakun` (`nomor`, `idLaporan`) VALUES
('41', 'L1501'),
('41', 'N1501'),
('42', 'L1501'),
('42', 'N1501'),
('43', 'L1501'),
('43', 'N1501'),
('51', 'L1501'),
('51', 'N1501'),
('52', 'L1501'),
('52', 'N1501'),
('53', 'L1501'),
('53', 'N1501');

-- --------------------------------------------------------

--
-- Table structure for table `_periode`
--

CREATE TABLE IF NOT EXISTS `_periode` (
  `idPeriode` varchar(6) NOT NULL,
  `tglAwal` date DEFAULT NULL,
  `tglAkhir` date DEFAULT NULL,
  PRIMARY KEY (`idPeriode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `_periode`
--

INSERT INTO `_periode` (`idPeriode`, `tglAwal`, `tglAkhir`) VALUES
('1501', '2015-01-01', '2015-01-31'),
('1502', '2015-02-01', '2015-02-28');

-- --------------------------------------------------------

--
-- Table structure for table `_periodeakun`
--

CREATE TABLE IF NOT EXISTS `_periodeakun` (
  `nomor` varchar(3) NOT NULL,
  `idPeriode` varchar(6) NOT NULL,
  `saldoAwal` bigint(20) DEFAULT NULL,
  `saldoAkhir` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`nomor`,`idPeriode`),
  KEY `fk__akun_has_periode_periode1_idx` (`idPeriode`),
  KEY `fk__akun_has_periode__akun1_idx` (`nomor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `_periodeakun`
--

INSERT INTO `_periodeakun` (`nomor`, `idPeriode`, `saldoAwal`, `saldoAkhir`) VALUES
('11', '1502', 30000000, 23208000),
('12', '1502', 20000000, 20000000),
('13', '1502', 3500000, 4292000),
('14', '1502', 0, 0),
('15', '1502', 10000000, 26000000),
('21', '1502', 13500000, 19500000),
('22', '1502', 0, 0),
('31', '1502', 50000000, 50000000),
('41', '1502', 0, 8000000),
('42', '1502', 0, 0),
('51', '1502', 0, 4000000),
('52', '1502', 0, 0),
('53', '1502', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `_transaksi`
--

CREATE TABLE IF NOT EXISTS `_transaksi` (
  `idTransaksi` varchar(3) NOT NULL,
  `keterangan` varchar(225) DEFAULT NULL,
  PRIMARY KEY (`idTransaksi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `_transaksi`
--

INSERT INTO `_transaksi` (`idTransaksi`, `keterangan`) VALUES
('001', 'Membeli bahan baku secara kredit'),
('002', 'Membeli bahan baku secara kredit'),
('003', 'Membuat Job Order no 123'),
('004', 'PPIC menerima bahan baku dari gudang'),
('005', 'Menghitung dan membebankan biaya tenaga kerja langsung terhadap Job Order no 123'),
('006', 'Membayar biaya tenaga kerja langsung secara tunai'),
('007', 'Menyelesaikan produksi Job Order no 123'),
('008', 'Menjual barang dagangan secara tunai'),
('009', 'Melunasi hutang secara tunai'),
('010', 'Pelunasan piutang dari cv abadi'),
('011', 'menjual barang dagangan secara kredit'),
('012', 'Membeli bahan baku secara tunai'),
('901', 'penutupan pendapatan'),
('902', 'penutupan biaya'),
('903', 'penutupan modal dan laba rugi'),
('904', 'penutupan modal dan prive');

-- --------------------------------------------------------

--
-- Structure for view `vlaporandaftarjurnal`
--
DROP TABLE IF EXISTS `vlaporandaftarjurnal`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vlaporandaftarjurnal` AS select `j`.`idJurnal` AS `idjurnal`,`j`.`tanggal` AS `tanggal`,`t`.`keterangan` AS `keterangan`,`a`.`nama` AS `nama`,`d`.`debet` AS `debet`,`d`.`kredit` AS `kredit`,`j`.`nomorBukti` AS `nomorBukti` from (((`_jurnal` `j` join `_transaksi` `t` on((`j`.`idTransaksi` = `t`.`idTransaksi`))) join `_detiljurnal` `d` on((`j`.`idJurnal` = `d`.`idJurnal`))) join `_akun` `a` on((`d`.`nomor` = `a`.`nomor`))) order by `j`.`idJurnal`,`d`.`noUrut`;

-- --------------------------------------------------------

--
-- Structure for view `vnotapembelian`
--
DROP TABLE IF EXISTS `vnotapembelian`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vnotapembelian` AS select `n`.`noNotaPembelian` AS `noNotaPembelian`,`n`.`idSupplier` AS `idSupplier`,`s`.`nama` AS `NamaSupplier`,`s`.`alamat` AS `Alamatsupplier`,`n`.`diskon` AS `diskon`,`n`.`totalHarga` AS `totalHarga`,`n`.`tglBatasPelunasan` AS `tglBatasPelunasan`,`n`.`tglBatasDiskon` AS `tglBatasDiskon`,`n`.`tglBeli` AS `tglbeli`,`n`.`status` AS `status`,`n`.`keterangan` AS `keterangan` from (`notapembelian` `n` join `supplier` `s` on((`n`.`idSupplier` = `s`.`idSupplier`))) order by `n`.`noNotaPembelian` desc;

-- --------------------------------------------------------

--
-- Structure for view `vnotapenjualan`
--
DROP TABLE IF EXISTS `vnotapenjualan`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vnotapenjualan` AS select `n`.`noNotaPenjualan` AS `noNotaPenjualan`,`n`.`idPelanggan` AS `idPelanggan`,`p`.`nama` AS `NamaPelanggan`,`p`.`alamat` AS `AlamatPelanggan`,`n`.`diskon` AS `diskon`,`n`.`totalHarga` AS `totalHarga`,`n`.`tglBatasPelunasan` AS `tglBatasPelunasan`,`n`.`tglBatasDiskon` AS `tglBatasDiskon`,`n`.`tglJual` AS `tglJual`,`n`.`status` AS `status`,`n`.`keterangan` AS `keterangan` from (`notapenjualan` `n` join `pelanggan` `p` on((`n`.`idPelanggan` = `p`.`idPelanggan`))) order by `n`.`noNotaPenjualan` desc;

-- --------------------------------------------------------

--
-- Structure for view `vsaldoakhir`
--
DROP TABLE IF EXISTS `vsaldoakhir`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vsaldoakhir` AS select `a`.`kelompok` AS `kelompok`,`a`.`nomor` AS `nomor`,`a`.`nama` AS `nama`,(`pa`.`saldoAwal` + ifnull(((sum(`d`.`debet`) - sum(`d`.`kredit`)) * `a`.`saldoNormal`),0)) AS `SaldoAkhir` from ((`_akun` `a` left join `_detiljurnal` `d` on((`a`.`nomor` = `d`.`nomor`))) join `_periodeakun` `pa` on((`a`.`nomor` = `pa`.`nomor`))) group by `a`.`nomor`,`a`.`nama`;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `detiljoborder`
--
ALTER TABLE `detiljoborder`
  ADD CONSTRAINT `fk_JobOrder_has_karyawan_JobOrder1` FOREIGN KEY (`kodeJobOrder`) REFERENCES `joborder` (`kodeJobOrder`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_JobOrder_has_karyawan_karyawan1` FOREIGN KEY (`idKaryawan`) REFERENCES `karyawan` (`idKaryawan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `detilnotabeli`
--
ALTER TABLE `detilnotabeli`
  ADD CONSTRAINT `fk_NotaPembelian_has_Barang_Barang1` FOREIGN KEY (`kodeBarang`) REFERENCES `barang` (`kodeBarang`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_NotaPembelian_has_Barang_NotaPembelian` FOREIGN KEY (`noNotaPembelian`) REFERENCES `notapembelian` (`noNotaPembelian`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `detilnotajual`
--
ALTER TABLE `detilnotajual`
  ADD CONSTRAINT `fk_NotaPenjualan_has_Barang_Barang1` FOREIGN KEY (`kodeBarang`) REFERENCES `barang` (`kodeBarang`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_NotaPenjualan_has_Barang_NotaPenjualan1` FOREIGN KEY (`noNotaPenjualan`) REFERENCES `notapenjualan` (`noNotaPenjualan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `detilsuratjalan`
--
ALTER TABLE `detilsuratjalan`
  ADD CONSTRAINT `fk_suratJalan_has_Barang_Barang1` FOREIGN KEY (`kodeBarang`) REFERENCES `barang` (`kodeBarang`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_suratJalan_has_Barang_suratJalan1` FOREIGN KEY (`noSuratJalan`) REFERENCES `suratjalan` (`noSuratJalan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `detilsuratpermintaan`
--
ALTER TABLE `detilsuratpermintaan`
  ADD CONSTRAINT `fk_Barang_has_suratPermintaan_Barang1` FOREIGN KEY (`kodeBarang`) REFERENCES `barang` (`kodeBarang`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Barang_has_suratPermintaan_suratPermintaan1` FOREIGN KEY (`noSuratPermintaan`) REFERENCES `suratpermintaan` (`noSuratPermintaan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `joborder`
--
ALTER TABLE `joborder`
  ADD CONSTRAINT `fk_JobOrder_Barang1` FOREIGN KEY (`kodeBarang`) REFERENCES `barang` (`kodeBarang`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_JobOrder_NotaPenjualan1` FOREIGN KEY (`noNotaPenjualan`) REFERENCES `notapenjualan` (`noNotaPenjualan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `notapembelian`
--
ALTER TABLE `notapembelian`
  ADD CONSTRAINT `fk_NotaPembelian_supplier1` FOREIGN KEY (`idSupplier`) REFERENCES `supplier` (`idSupplier`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `notapenjualan`
--
ALTER TABLE `notapenjualan`
  ADD CONSTRAINT `fk_NotaPenjualan_Pelanggan1` FOREIGN KEY (`idPelanggan`) REFERENCES `pelanggan` (`idPelanggan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `pelunasan`
--
ALTER TABLE `pelunasan`
  ADD CONSTRAINT `fk_Pelunasan_NotaPenjualan1` FOREIGN KEY (`noNotaPenjualan`) REFERENCES `notapenjualan` (`noNotaPenjualan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `pembayaran`
--
ALTER TABLE `pembayaran`
  ADD CONSTRAINT `fk_pembayaran_NotaPembelian1` FOREIGN KEY (`noNotaPembelian`) REFERENCES `notapembelian` (`noNotaPembelian`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `penerimaan`
--
ALTER TABLE `penerimaan`
  ADD CONSTRAINT `fk_penerimaan_NotaPembelian1` FOREIGN KEY (`noNotaPembelian`) REFERENCES `notapembelian` (`noNotaPembelian`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `pengiriman`
--
ALTER TABLE `pengiriman`
  ADD CONSTRAINT `fk_pengiriman_ekspedisi1` FOREIGN KEY (`idEkspedisi`) REFERENCES `ekspedisi` (`idEkspedisi`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_pengiriman_NotaPenjualan1` FOREIGN KEY (`noNotaPenjualan`) REFERENCES `notapenjualan` (`noNotaPenjualan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `suratjalan`
--
ALTER TABLE `suratjalan`
  ADD CONSTRAINT `fk_suratJalan_suratPermintaan1` FOREIGN KEY (`noSuratPermintaan`) REFERENCES `suratpermintaan` (`noSuratPermintaan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `suratpermintaan`
--
ALTER TABLE `suratpermintaan`
  ADD CONSTRAINT `fk_suratPermintaan_JobOrder1` FOREIGN KEY (`kodeJobOrder`) REFERENCES `joborder` (`kodeJobOrder`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `_detiljurnal`
--
ALTER TABLE `_detiljurnal`
  ADD CONSTRAINT `fk__detilJurnal__jurnal1` FOREIGN KEY (`idJurnal`) REFERENCES `_jurnal` (`idJurnal`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk__jurnal_has__akun__akun1` FOREIGN KEY (`nomor`) REFERENCES `_akun` (`nomor`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `_jurnal`
--
ALTER TABLE `_jurnal`
  ADD CONSTRAINT `fk__jurnal_periode1` FOREIGN KEY (`idPeriode`) REFERENCES `_periode` (`idPeriode`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk__jurnal__transaksi1` FOREIGN KEY (`idTransaksi`) REFERENCES `_transaksi` (`idTransaksi`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `_laporan`
--
ALTER TABLE `_laporan`
  ADD CONSTRAINT `fk__laporan__periode1` FOREIGN KEY (`idPeriode`) REFERENCES `_periode` (`idPeriode`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `_laporanakun`
--
ALTER TABLE `_laporanakun`
  ADD CONSTRAINT `fk__akun_has__laporan__akun1` FOREIGN KEY (`nomor`) REFERENCES `_akun` (`nomor`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk__akun_has__laporan__laporan1` FOREIGN KEY (`idLaporan`) REFERENCES `_laporan` (`idLaporan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `_periodeakun`
--
ALTER TABLE `_periodeakun`
  ADD CONSTRAINT `fk__akun_has_periode_periode1` FOREIGN KEY (`idPeriode`) REFERENCES `_periode` (`idPeriode`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk__akun_has_periode__akun1` FOREIGN KEY (`nomor`) REFERENCES `_akun` (`nomor`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
