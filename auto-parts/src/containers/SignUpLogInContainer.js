import React, { useState } from 'react';
import { Paper, Tabs, Tab } from '@material-ui/core';
import TabPanel from '../components/tabpanel';
import Login from '../components/login';
import SignUp from '../components/signup';

const SignUpLogInContainer = () => {
  const [value, setValue] = useState(0);
  const handleChange = (event, newValue) => {
    setValue(newValue);
  };
  const paperStyle = { width: 320, margin: '20px auto' };

  return (
    <div>
      <Paper elevation={20} style={paperStyle}>
        <Tabs
          indicatorColor="primary"
          value={value}
          onChange={handleChange}
          aria-label="disabled tabs example"
        >
          <Tab label="Sign In" />
          <Tab label="Sign Up" />
        </Tabs>
        <TabPanel value={value} index={0}>
          <Login handleChange={handleChange}></Login>
        </TabPanel>
        <TabPanel value={value} index={1}>
          <SignUp handleChange={handleChange}></SignUp>
        </TabPanel>
      </Paper>
    </div>
  );
};

export default SignUpLogInContainer;
