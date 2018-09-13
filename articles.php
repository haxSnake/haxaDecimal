<?php
  require_once("connect_ldb.php");

  if(!isset($_SESSION)){
    session_start();
  }

  if(isset($_SESSION["user"])!=""){
    header("Location: blank.html");
  }
?>

<html lang="en">

<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
  <title>Money portal</title>
  <!-- Bootstrap core CSS-->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Custom fonts for this template-->
  <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
  <!-- Custom styles for this template-->
  <link href="css/sb-admin.css" rel="stylesheet">
</head>

<body class="fixed-nav sticky-footer bg-dark" id="page-top">
    <!-- Navigation-->
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" id="mainNav">
    <a class="navbar-brand" href="index.html">haxaDecimal</a>
    <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarResponsive">
      <ul class="navbar-nav navbar-sidenav" id="exampleAccordion">
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Dashboard">
          <a class="nav-link" href="index.php">
            <i class="fa fa-fw fa-dashboard"></i>
            <span class="nav-link-text">Dashboard</span>
          </a>
        </li>
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
          <a class="nav-link" href="charts.php">
            <i class="fa fa-fw fa-area-chart"></i>
            <span class="nav-link-text">Finances</span>
          </a>
        </li>
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Tables">
          <a class="nav-link" href="tables.php">
            <i class="fa fa-fw fa-table"></i>
            <span class="nav-link-text">Transactions</span>
          </a>
        </li>

        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Link">
          <a class="nav-link" href="articles.php">
            <i class="fa fa-fw fa-link"></i>
            <span class="nav-link-text">Articles</span>
          </a>
        </li>
      </ul>
      <ul class="navbar-nav sidenav-toggler">
        <li class="nav-item">
          <a class="nav-link text-center" id="sidenavToggler">
            <i class="fa fa-fw fa-angle-left"></i>
          </a>
        </li>
      </ul>
      <ul class="navbar-nav ml-auto">

        <li class="nav-item">
          <a class="nav-link" data-toggle="modal" data-target="#exampleModal">
            <i class="fa fa-fw fa-sign-out"></i>Logout</a>
        </li>
      </ul>
    </div>
  </nav>
  <div class="content-wrapper">
    <div class="container-fluid">
      <!-- Breadcrumbs-->
      <ol class="breadcrumb">
        <li class="breadcrumb-item">
			<a href="index.html">Dashboard</a>
        </li>
        <li class="breadcrumb-item active">Articles</li>
      </ol>
<div class="row">
				<div class="col-md-8 blog-main">
				
				<?php $q = "SELECT * FROM article" ;
					$r = mysqli_query( $con, $q ) ;									
					if ( mysqli_num_rows( $r ) > 0 ) {  
						# Display list of articles.
						while ($row = mysqli_fetch_array($r, MYSQLI_ASSOC)) {
						echo
						'<a href="article.php?id=' . $row['artId'] . '"><div class="jumbotron p-3 p-md-5 text-light rounded bg-success">
							<div class="col-md-6 px-0">
								<h1 class="display-4 font-italic">' . $row['artTitle'] . '</h1>
								<p class="lead mb-0 text-white font-weight-bold">by ' . $row['artAuthor'] . '</p>
							</div>
						</div></a>';
						}
					}
				?>
				



				</div><!-- /.blog-main -->

				<aside class="col-md-4 blog-sidebar">

				  
				  <?php $q = "SELECT * FROM article" ;
					$r = mysqli_query( $con, $q ) ;
					echo 
					'<div class="p-3">
						<h4 class="font-italic">Other articles</h4>
						<ol class="list-unstyled mb-0">';					
					if ( mysqli_num_rows( $r ) > 0 ) {  
						# Display list of articles.
						while ($row = mysqli_fetch_array($r, MYSQLI_ASSOC)) {
						echo
						'<li><a href="article.php?id=' . $row['artId'] . '">' . $row['artTitle'] . '</a></li>';
						}
					}?>

				  <div class="p-3">
					<h4 class="font-italic">Keep in touch</h4>
					<ol class="list-unstyled">
					  <li><a href="#">Instagram</a></li>
					  <li><a href="#">Twitter</a></li>
					  <li><a href="#">Facebook</a></li>
					</ol>
				  </div>
				</aside><!-- /.blog-sidebar -->

			</div><!-- /.row -->
    </div>
    <!-- /.container-fluid-->
    <!-- /.content-wrapper-->
    <footer class="sticky-footer">
      <div class="container">
        <div class="text-center">
          <small>Copyright © haxadecimal 2018</small>
        </div>
      </div>
    </footer>
    <!-- Scroll to Top Button-->
    <a class="scroll-to-top rounded" href="#page-top">
      <i class="fa fa-angle-up"></i>
    </a>
    <!-- Logout Modal-->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">×</span>
            </button>
          </div>
          <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
          <div class="modal-footer">
            <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
            <a class="btn btn-primary" href="login.html">Logout</a>
          </div>
        </div>
      </div>
    </div>
    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin.min.js"></script>
  </div>
</body>

</html>