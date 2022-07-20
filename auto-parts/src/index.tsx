import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import CustomAppBar from '../src/components/appbar';
import Routes from '../src/router/routes';
import { BrowserRouter as Router } from 'react-router-dom';
import { Provider } from 'react-redux';
import { store, persistor } from './redux/store';
import { PersistGate } from 'redux-persist/integration/react';

ReactDOM.render(
  <Provider store={store}>
    <PersistGate loading={null} persistor={persistor}>
      <Router>
        <div className="App">
          <CustomAppBar />
          <Routes />
        </div>
      </Router>
    </PersistGate>
  </Provider>,
  document.getElementById('root')
);
