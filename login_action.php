<?php # PROCESS LOGIN ATTEMPT.

# Check form submitted.
if ( $_SERVER[ 'REQUEST_METHOD' ] == 'POST' )
{
  # Open database connection.
  require ( 'connect_ldb.php' ) ;

  # Get connection, load, and validate functions.
  require ( 'login_tools.php' ) ;

  # Check login.
  list ( $check, $data ) = validate ( $con, $_POST[ 'email' ], $_POST[ 'password' ] ) ;

  # On success set session data and display logged in page.
  if ( $check )
  {
    # Access session.
    session_start();
    $_SESSION[ 'userId' ] = $data[ 'userId' ] ;
    $_SESSION[ 'firstName' ] = $data[ 'firstName' ] ;
    $_SESSION[ 'lastName' ] = $data[ 'lastName' ] ;
    load ( 'index.php' ) ; #.php HERE
  }
  # Or on failure set errors.
  else { $errors = $data; }

  # Close database connection.
 mysqli_close( $con ) ;
}

# Continue to display login page on failure.
include ( 'login.php' ) ;

?>
