<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

<style type="text/css">
	img{
		height: 15mm;
		width: 50mm;
		display: block;
  		margin-left: auto;
  		margin-right: auto;
		text-align: center;
	}

	body{
		max-width: 80mm;
		height: 120mm;
	}

	@media print 
	{
	   @page
	   {
	    margin: 0.05in;
	    size: portrait;
	  }
	}
	

	table tr td{
		font-size: 1.5mm;
	}
	
	table tr th{
		font-size: 1.5mm;
	}

	p{
		font-size: 2.15mm!important;
	}

	label{
		font-size:2.5mm;
	}

	div{
		font-size:2.5mm;
	}
</style>	
</head>
<body>
<div class="container-fluid">
	<div class="row">
		<div class="col text-center">
			<img src="{{asset('img/logo.jpg')}}">
		</div>
	</div>
<hr>
	<div class="row justify-content-center">
		<div class="col-3">
			<p style="text-align:center; font-weight: bold">
				JL.RAYA CIBADUYUT NO.60,<br>
				66 BANDUNG JAWA BARAT<br>
				Tlp 022-5423013-5423014<br>
			</p>						

		</div>
	</div>

	<div class="row">
		<div class="col">
			<table>
				<tr>
					<td>NO STRUK</td>
					<td> : {{$datas->no_struk}}</td>
				</tr>
				<tr>
					<td>NO REGESTER</td>
					<td> : {{$datas->no_register}}</td>
				</tr>
				<tr>
					<td>TANGGAL</td>
					<td> :  {{$datas->tanggal}}</td>
				</tr>
				<tr>
					<td>KASIR</td>
					<td> :  {{$datas->kasir}}</td>
				</tr>
				<tr>
					<td>NO KUNJUNGAN</td>
					<td> :  {{$datas->no_kunjungan}}</td>
				</tr>
				<tr>
					<td>CUSTOMER</td>
					<td> : {{$datas->customer}}</td>
				</tr>
			</table>
			<br>
			<label>LIST BARANG</label>
			<hr>
			@php
				//dd($datas);
			@endphp
			<table style="width: 100%">
			  
			  <thead>
					<tr>
						<th class="text-right">ITEM</th>
						<th class="text-center">QTY</th>
						<th class="text-center">HARGA</th>
						<th class="text-center">JUMLAH</th>
					</tr>
				</thead>
			  <tbody>
					<tr>
						<td>{{$datas->item}}</td>
						<td class="text-center">{{$datas->qty}}</td>
						<td class="text-right">Rp. {{number_format($datas->harga)}}</td>
						<td class="text-right">Rp. {{number_format($datas->jumlah)}}</td>
					</tr>
				</tbody>
			</table>
			<hr>
		</div>
	</div>

	<table style="width: 100%">
		<tr>
			<th style="text-align: left">TOTAL QTY</th>
			<th  style="text-align: right">{{$datas->total_qty}}</th>
		</tr>
		<tr>
			<th style="text-align: left">TOTAL BAYAR</th>
			<th  style="text-align: right">Rp. {{number_format($datas->total_bayar)}}</th>
		</tr>
		<tr>
			<th style="text-align: left">PROMO</th>
			<th  style="text-align: right">Rp. {{number_format($datas->promo)}}</th>
		</tr>
		<tr>
			<th style="text-align: left">SALDO KONSUMEN</th>
			<th  style="text-align: right">Rp. {{number_format($datas->saldo_konsumen)}}</th>
		</tr>
		<tr>
			<th style="text-align: left">RETURN PENJUALAN</th>
			<th  style="text-align: right">Rp. {{number_format($datas->retur_penjualan)}}</th>
		</tr>
		<tr>
			<th style="text-align: left">PIUTANG</th>
			<th  style="text-align: right">Rp. {{number_format($datas->piutang)}}</th>
		</tr>
		<tr>
			<th style="text-align: left">KEMBALIAN</th>
			<th  style="text-align: right">Rp. {{number_format($datas->kembalian)}}</th>
		</tr>
		<tr>
			<th style="text-align: left">SISA SALDO</th>
			<th  style="text-align: right">Rp. {{number_format($datas->sisa_saldo)}}</th>
		</tr>
	</table>

	<div class="row justify-content-center">
		<div class="col-3">
			<p style="text-align:center; font-weight: bold">
				TERIMAKASIH<br>
				SEMOGA ANDA PUAS ATAS<br>
				PELAYANAN KAMI<br>
			</p>						

		</div>
	</div>
</div>
</body>
</html>

<script type="text/javascript">
	window.print();
</script>
