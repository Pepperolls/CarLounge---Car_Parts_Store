import { AppBar } from '@material-ui/core';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import NavBarList from '../components/navbarlist';
import ListItemIcon from '@mui/material/ListItemIcon';
import ShoppingCartOutlinedIcon from '@mui/icons-material/ShoppingCartOutlined';
import history from '../history/history';
import { red } from '@mui/material/colors';

const CustomAppBar = () => {
  const iconStyle = {
    fontSize: 30,
    color: red[50],
  };
  return (
    <Box sx={{ flexGrow: 1 }} mb={8}>
      <AppBar position="fixed">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            <NavBarList></NavBarList>
          </Typography>
          {/* <Button onClick={() => history.push('/')}> */}

          <Button onClick={() => history.push('/Cart')}>
            <ListItemIcon minwidth="40px">
              <ShoppingCartOutlinedIcon style={iconStyle} />
            </ListItemIcon>
          </Button>
          <Button
            variant="contained"
            color="secondary"
            size="large"
            onClick={() => history.push('/LogIn')}
            style={{ margin: '0 8px 0 0' }}
          >
            Sign In
          </Button>
          <Button
            variant="contained"
            color="secondary"
            size="large"
            onClick={() => history.push('/SignUp')}
          >
            Sign Up
          </Button>
        </Toolbar>
      </AppBar>
    </Box>
  );
};

export default CustomAppBar;
