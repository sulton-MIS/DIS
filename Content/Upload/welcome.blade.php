<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css">
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.12.1/css/all.min.css">
    <title>Grutty</title>
  </head>
  <style type="text/css">
      body {
        width: 100%;
      }

      th {
        font-size: 12px;
        font-weight: 700;
        white-space: nowrap;
        border-bottom:2px solid black;
      }

      td {
        font-size: 12px;
        white-space: nowrap;
        vertical-align: middle;
      }

      h1 {
      font-size: 24pt;
      }

      h2, h3, h4 {
      font-size: 14pt;
      margin: 
      }

      label{
        margin-top: 10px;
      }
  </style>
  <body>
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                    <h2 class="text-center"><b>DATA PENJUALAN</b></h2>
                    <hr style="border-bottom:1px solid grey">
                    
                    <button class="btn btn-success text-white" onclick="document.getElementById('file').click()"><i class="fa fa-file"></i> Upload</button> <button class="btn btn-danger text-white" onclick="location.href = 'clear_db' "><i class="fa fa-eraser"></i> Clear Table</button> 
                    <button class="btn btn-primary" onclick="window.location.href = 'pajak.xlsx' "><i class="fa fa-download"></i> Download XLS Upload</button>
                    <hr>
                    <div class="row">
                      <div class="col-5">
                        <!-- Button trigger modal -->
                        {{-- <button type="button" class="btn btn-info" data-toggle="modal" data-target="#exampleModalLong">
                          Printer Setting
                        </button> --}}
                        
                        <!-- Modal -->
                        <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
                          <div class="modal-dialog modal-dialog-scrollable|modal-dialog-centered modal-sm|modal-lg|modal-xl" role="document">
                            <div class="modal-content">
                              <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLongTitle">Print Settings</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                  <span aria-hidden="true">&times;</span>
                                </button>
                              </div>
                              <div class="modal-body">
                                <div class="form-group">
                                  <label></label>
                                </div>
                              </div>
                              <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                <button type="button" class="btn btn-primary">Save changes</button>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="col-1 text-right">
                        <label>From : </label>
                      </div>
                      <div class="col-2">
                        <input type="date" class="form-control" id="date1" name="">
                      </div>
                      <div class="col-1 text-right">
                        <label>From : </label>
                      </div>
                      <div class="col-2">
                        <input type="date" class="form-control" id="date2" name="">
                      </div>
                      <div class="col-1">
                        <button class="btn btn-info" onclick="filterz()"><i class="fa fa-filter"></i> Filter</button>
                      </div>
                    </div>

                    <form id="form" action="upload" method="POST" enctype="multipart/form-data">
                        @csrf
                        <input type="file" id="file" style="display:none" name="file_upload">
                    </form>
                    <hr>

                    <div id="data-tables">
                      @include('table')
                    </div>
                </div>
        </div>
    </div>

    <div id="printable" style="margin-bottom:20px">

    </div>
    
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.form/4.2.2/jquery.form.js"></script> 
    <script type="text/javascript">
        //On Change show alert submit
        $('#file').change(function(){
            $('#form').submit();
        });

        function printz(id){
          $.ajax({
            url: "print/"+id,
            success:function(res){
              $('#printable').html(res);
              window.print();
            },
            error: function(res){
              alert("Something Error");
            }
          });
        }

        $(document).ready(
            function(){
                $('.data-table').DataTable();
            }
        );

        function filterz(){
          var date1 = $('#date1').val();
          var date2 = $('#date2').val();
          $.ajax({
            url: "Table",
            data: {
              date1 : date1,
              date2: date2
            },
            success: function (res){
              $('#data-tables').html(res);
              $('.data-table').DataTable();
            },
            error: function (res){
              alert("Something Error");
            }
          });
        }
    </script>
  </body>
</html>