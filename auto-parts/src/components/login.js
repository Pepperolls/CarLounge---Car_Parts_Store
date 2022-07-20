import history from '../history/history';
import {
  Grid,
  Paper,
  Button,
  TextField,
  Typography,
  Link,
} from '@material-ui/core';

const Login = () => {
  const paperStyle = {
    padding: 20,
    height: '43vh',
    width: 280,
    margin: '0 auto',
  };

  return (
    <Grid align="center">
      <Paper style={paperStyle}>
        <img
          src="/images/Logo_blue.png"
          alt="Blue car logo"
          height={150}
          width={275}
          style={{ alignSelf: 'center' }}
        />
        {/* <h2 style={{ color: '#3f51b5' }}>Sign In</h2> */}
        <TextField
          margin="normal"
          variant="outlined"
          label="Enter e-mail"
          fullWidth
          required
        />
        <TextField
          margin="normal"
          variant="outlined"
          type="password"
          label="Enter password"
          fullWidth
          required
        />
        <Button
          type="submit"
          color="primary"
          variant="contained"
          fullWidth
          style={{ margin: '8px 0' }}
          onClick={() => history.push('/')}
        >
          Sign In
        </Button>
        <Typography>
          <Link href="#">Forgot password</Link>
        </Typography>
        <Typography>
          {' '}
          Don't have an account?
          <Link href="#" onClick={() => history.push('/SignUp')}>
            {' '}
            Sign Up
          </Link>
        </Typography>
      </Paper>
    </Grid>
  );
};

export default Login;
