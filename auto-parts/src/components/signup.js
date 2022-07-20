import history from '../history/history';
import {
  Grid,
  Paper,
  Button,
  TextField,
  Typography,
  Link,
} from '@material-ui/core';

const SignUp = () => {
  const paperStyle = {
    padding: 20,
    height: '67vh',
    width: 280,
    margin: '0 auto',
  };
  const btnStyle = {
    margin: '8px 0',
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
        {/* <h2 style={{ color: '#3f51b5' }}>Sign Up</h2> */}
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
        <TextField
          margin="normal"
          variant="outlined"
          label="Enter First Name"
          fullWidth
          required
        />
        <TextField
          margin="normal"
          variant="outlined"
          label="Enter First Name"
          fullWidth
          required
        />
        <TextField
          margin="normal"
          variant="outlined"
          label="Enter Personal ID No."
          fullWidth
          required
        />
        <Button
          type="submit"
          color="primary"
          variant="contained"
          fullWidth
          style={btnStyle}
          onClick={() => history.push('/LogIn')}
        >
          Sign Up
        </Button>
        <Typography>
          {' '}
          Already have an account?
          <Link href="#" onClick={() => history.push('/LogIn')}>
            {' '}
            Sign In
          </Link>
        </Typography>
      </Paper>
    </Grid>
  );
};

export default SignUp;
