<?php # LOGIN HELPER FUNCTIONS.

# Function to load specified or default URL.
function load( $page = 'login.php' )
{
  # Begin URL with protocol, domain, and current directory.
  $url = 'http://' . $_SERVER[ 'HTTP_HOST' ] . dirname( $_SERVER[ 'PHP_SELF' ] ) ;

  # Remove trailing slashes then append page name to URL.
  $url = rtrim( $url, '/\\' ) ;
  $url .= '/' . $page ;

  # Execute redirect then quit.
  header( "Location: $url" ) ;
  exit() ;
}

# Function to check email address and password.
function validate( $con, $email = '', $password = '')
{
  # Initialize errors array.
  $errors = array() ;

  # Check email field.
  if ( empty( $email ) )
  { $errors[] = 'Enter your email address.' ; }
  else  { $e = mysqli_real_escape_string( $con, trim( $email ) ) ; } # enter into email

  # Check password field.
  if ( empty( $password ) )
  { $errors[] = 'Enter your password.' ; }
  else { $p = mysqli_real_escape_string( $con, trim( $password ) ) ; } # enter into password

  # On success retrieve user_id, first_name, and last name from 'users' database.
  if ( empty( $errors ) )
  {
    $q = "SELECT userId, firstName, lastName FROM user WHERE email='$e' AND pw='$p'" ;
    $r = mysqli_query ( $con, $q ) ;
    if ( @mysqli_num_rows( $r ) == 1 )
    {
      $row = mysqli_fetch_array ( $r, MYSQLI_ASSOC ) ;
      return array( true, $row ) ;
    }
    # Or on failure set error message.
    else { $errors[] = 'Email address and password not found.' ; }
  }
  # On failure retrieve error message/s.
  return array( false, $errors ) ;
}
