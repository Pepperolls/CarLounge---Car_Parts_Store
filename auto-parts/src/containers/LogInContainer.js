import { Paper } from '@material-ui/core';
import TabPanel from '../components/tabpanel';
import Login from '../components/login';
import Footer from '../components/footer';

const LogInContainer = () => {
  const paperStyle = { width: 320, margin: '20px auto' };

  return (
    <div>
      <Paper elevation={20} style={paperStyle}>
        <TabPanel>
          <Login></Login>
        </TabPanel>
      </Paper>
      <Footer></Footer>
    </div>
  );
};

export default LogInContainer;
