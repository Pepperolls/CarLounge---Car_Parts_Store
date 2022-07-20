import { Typography } from '@material-ui/core';
import { red } from '@material-ui/core/colors';

const ToBeContinued = () => {
  return (
    <div
      style={{
        height: '93.2vh',
        width: '100vw',
        backgroundColor: '#3f51b5',
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center',
      }}
    >
      <Typography variant="h1" align="center" style={{ color: red[50] }}>
        We currently do not support taking your money.
      </Typography>
      <Typography variant="h1" align="center" style={{ color: red[50] }}>
        Feel free to browse back to the application using the NavBar.
      </Typography>
    </div>
  );
};

export default ToBeContinued;
