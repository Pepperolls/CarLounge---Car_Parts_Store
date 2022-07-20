import { Component } from 'react';
import { Router, Switch, Route } from 'react-router-dom';
import history from '../history/history';
import HomePageContainer from '../containers/HomePageContainer';
import ProductsContainer from '../containers/ProductsContainer';
import LogInContainer from '../containers/LogInContainer';
import SignUpContainer from '../containers/SignUpContainer';
import CartContainer from '../containers/CartContainer';
import ToBeContinued from '../containers/ToBeContinuedContainer';

export default class Routes extends Component {
  render() {
    return (
      <Router history={history}>
        <Switch>
          <Route path="/" exact component={HomePageContainer} />
          <Route path="/Products" component={ProductsContainer} />
          <Route path="/Cart" component={CartContainer} />
          <Route path="/SignUp" component={SignUpContainer} />
          <Route path="/LogIn" component={LogInContainer} />
          <Route path="/ToBeContinued" component={ToBeContinued} />
        </Switch>
      </Router>
    );
  }
}
