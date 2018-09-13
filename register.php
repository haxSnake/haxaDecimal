<?php
  require_once("connect_ldb.php");

  if(!isset($_SESSION)){
    session_start();
  }

  if(isset($_SESSION["email"])!=""){
    header("Location: register.php");
  }
?>


<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
  <title>User Panel</title>
  <!-- Bootstrap core CSS-->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Custom fonts for this template-->
  <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
  <!-- Custom styles for this template-->
  <link href="css/sb-admin.css" rel="stylesheet">
</head>

<body class="login-bg">
  <?php
    if(!isset($_POST["submit"])){
  ?>
  <div class="container">
    <div class="card card-register mx-auto mt-5">
      <div class="card-header">Register an Account</div>
      <form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>" method="post">

      <div class="card-body">
          <div class="form-group">
            <label for="user_name">Username</label>
            <input class="form-control" id="userId" type="userId" aria-describedby="usernameHelp" placeholder="Enter Username" name ="userId">
          </div>
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="password">Password</label>
                <input class="form-control" id="password" type="password" placeholder="Password" name="password">
              </div>
              <div class="col-md-6">
                <label for="confirm_password">Confirm password</label>
                <input class="form-control" id="confirm_password" type="password" placeholder="Confirm password" name="confirm_password">
              </div>
            </div>
          </div>
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="email">Email Address</label>
                <input class="form-control" id="email" type="text" aria-describedby="emailHelp" placeholder="Enter Email" name="email">
              </div>
              <div class="col-md-6">
                <label for="dob">Date Of Birth</label>
                <input class="form-control" id="dob" type="text" aria-describedby="DOBHelp" placeholder="Enter DOB" name="dob">
              </div>
            </div>
          </div>
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="firstName">First name</label>
                <input class="form-control" id="firstName" type="text" aria-describedby="firstnameHelp" placeholder="Enter first name" name="firstName">
              </div>
              <div class="col-md-6">
                <label for="lastName">Last name</label>
                <input class="form-control" id="lastName" type="text" aria-describedby="lastnameHelp" placeholder="Enter last name" name="lastName">
              </div>
            </div>
          </div>
          <div class="form-group">
            <label for="address">Address</label>
            <input class="form-control" id="address" type="text" aria-describedby="addressHelp" placeholder="Enter address" name="address">
          </div>
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="city">City</label>
                <input class="form-control" id="city" type="text" aria-describedby="cityHelp" placeholder="Enter City" name="city">
              </div>
              <div class="col-md-6">
                <label for="postcode">Postcode</label>
                <input class="form-control" id="postcode" type="text" aria-describedby="postcodeHelp" placeholder="Enter Postcode" name="postcode">
              </div>
            </div>
          </div>
          <div class="form-group">
            <label for="country">Country</label>
            <input class="form-control" id="country" type="text" aria-describedby="countryHelp" placeholder="Enter Country" name="country">
          </div>

          <button class="btn btn-primary btn-block" href="login.php" for="confirm_password" type="submit" name="submit">Register</button>
        </form>
        <div class="text-center">
          <a class="d-block small mt-3" href="login.php">Login Page</a>
          <a class="d-block small" href="forgot-password.html">Forgot Password?</a>
        </div>
      </div>
    </div>
  </div>
</body>
  <?php
	} else {
		// Prepare data to insert into the DB
    $userId	= $_POST['userId'];
    $address	= $_POST['address'];
    $postcode	= $_POST['postcode'];
		$city	= $_POST['city'];
    $dob	= $_POST['dob'];
    $country	= $_POST['country'];
		$firstName	= $_POST['firstName'];
		$lastName	= $_POST['lastName'];
		$email		= $_POST['email'];
		$password	= $_POST['password'];
		$confirm_password = $_POST['confirm_password'];


		if($password == $confirm_password){


			$encrypted_password = bin2hex($password);

		} else {
			echo "<script language=\"JavaScript\">\n";
			echo "alert('Password confirm failed!');\n";
			echo "window.location='register.php'";
			echo "</script>";
			exit();

		}

		// Checks if Username and Email exists. If not insert into the DB
		$exists = 0;

		// DB Queries
		$check_user_email = "SELECT email from user WHERE email = '$email' LIMIT 1";

		// Run DB Queries
		$run_check_user_email_query = mysqli_query($con, $check_user_email);

		// Checks the number of rows(entries) on the DB for Username and Email
		$num_row_email = mysqli_num_rows($run_check_user_email_query);


			$result = $num_row_email;
			if ($result == 1) $exists = 1;


		if ($exists == 1){
			echo "<script language=\"JavaScript\">\n";
			echo "alert('Email already exists!');\n";
			echo "window.location='register.php'";
			echo "</script>";
			exit();

		} else {
			// Insert data into DB
			$insert_admin = "INSERT INTO user(userId, firstName, lastName, dob, email, pw, street, postcode, city, country)
						VALUES ('$userId', '$firstName', '$lastName', '$dob', '$email', '$password', '$address', '$postcode', '$city', '$country')";

			$insert_admin_query = mysqli_query($con, $insert_admin);

			if ($insert_admin_query) {

				mysqli_close($con);

				echo "<script language=\"JavaScript\">\n";
				echo "alert('User Successfully Registered!');\n";

				//Redirect to index.php
				echo "window.location='register.php'";
				echo "</script>";

			} else {
		 		echo "Error Inserting Admin: " . mysqli_connect_errno();
				exit();

			}
		}
	}
  ?>
  <!-- Bootstrap core JavaScript-->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <!-- Core plugin JavaScript-->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
