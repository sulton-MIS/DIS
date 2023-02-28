<table target="_blank" class="table table-hover table-condensed table-striped data-table" >
  <caption>List of Penjualan</caption>
  <thead class="thead-light">
    <tr>
      <th scope="col">No</th>
      <th scope="col">NO STRUK</th>
      <th scope="col">NO REGISTER</th>
      <th scope="col">TANGGAL</th>
      <th scope="col">ITEM</th>
      <th scope="col">QTY</th>
      <th scope="col">JUMLAH</th>
      <th scope="col">TTL QTY</th>
      <th scope="col">TTL BAYAR</th>
      <th scope="col">KEMBALIAN</th>
      <th scope="col">ACTION</th>
      
    </tr>
  </thead>
  <tbody>
    @php 
        $no = 1;
    @endphp
    @foreach($datas as $data)
    <tr>
      <td>{{$no++}}</td>
      <td>{{$data["no_struk"]}}</td>
      <td>{{$data["no_register"]}}</td>
      <td>{{$data["tanggal"]}}</td>
      <td>{{$data["item"]}}</td>
      <td class="text-center">{{$data["qty"]}}</td>
      <td>Rp. {{number_format($data["jumlah"])}}</td>
      <td class="text-center">{{$data["total_qty"]}}</td>
      <td>Rp. {{number_format($data["total_bayar"])}}</td>
      <td>Rp. {{number_format($data["kembalian"])}}</td>
      <td class="text-center"><button onclick="window.open('print/{{$data["id"]}}','_blank') " class="btn btn-primary btn-sm"><i class="fa fa-print"></i> Print</button> 
        {{-- <button onclick="window.location.href = 'print_pdf/{{$data["id"]}}' " class="btn btn-danger btn-sm">PDF</button> --}}
      </td>
    </tr>
    @endforeach
  </tbody>
</table>