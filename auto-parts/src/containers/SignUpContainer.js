import { Paper } from '@material-ui/core';
import TabPanel from '../components/tabpanel';
import SignUp from '../components/signup';
import Footer from '../components/footer';

const LogInContainer = () => {
  const paperStyle = { width: 320, margin: '20px auto' };

  return (
    <div>
      <Paper elevation={20} style={paperStyle}>
        <TabPanel>
          <SignUp></SignUp>
        </TabPanel>
      </Paper>
      <Footer />
    </div>
  );
};

export default LogInContainer;
