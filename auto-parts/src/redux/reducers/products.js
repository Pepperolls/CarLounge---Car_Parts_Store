import {
  FETCHING_PRODUCTS,
  FETCH_PRODUCTS_SUCCESS,
  FETCH_PRODUCTS_FAIL,
  ADD_TO_CART,
  REMOVE_FROM_CART,
  ADD_TO_FAVORITES,
  REMOVE_FROM_FAVORITES,
  ADD_PRICE_TO_TOTAL,
  CHANGE_QUANTITY,
} from '../actions/productActions';
import { REHYDRATE } from 'redux-persist';

const initialState = {
  parts: [],
  isLoadingParts: false,
  partsAddedToCart: [],
  partsAddedToFavorites: [],
  totalSum: 0,
};

export default function (state = initialState, action) {
  console.log('Product reducer', action);
  switch (action.type) {
    case REHYDRATE: {
      return {
        ...initialState,
        partsAddedToCart: action.payload
          ? action.payload.products.partsAddedToCart.map(part => {
              return {
                ...part,
                quantity: parseInt(part.quantity),
              };
            })
          : [],
        partsAddedToFavorites: action.payload
          ? action.payload.products.partsAddedToFavorites
          : [],
        totalSum: action.payload ? action.payload.products.totalSum : 0,
      };
    }
    case FETCHING_PRODUCTS: {
      return {
        ...state,
        isLoadingParts: true,
      };
    }
    case FETCH_PRODUCTS_FAIL: {
      return {
        ...state,
        isLoadingParts: false,
      };
    }
    case FETCH_PRODUCTS_SUCCESS: {
      const parts = action.parts;
      return {
        ...state,
        isLoadingParts: false,
        parts,
      };
    }
    case ADD_TO_CART: {
      const partId = action.partId;
      return {
        ...state,
        partsAddedToCart: [
          ...new Set([...state.partsAddedToCart, { partId, quantity: 1 }]),
        ],
      };
    }
    case REMOVE_FROM_CART: {
      const partId = action.partId;
      return {
        ...state,
        partsAddedToCart: state.partsAddedToCart.filter(
          p => p.partId !== partId
        ),
      };
    }
    case ADD_TO_FAVORITES: {
      const partId = action.partId;
      return {
        ...state,
        partsAddedToFavorites: [
          ...new Set([...state.partsAddedToFavorites, partId]),
        ],
      };
    }
    case REMOVE_FROM_FAVORITES: {
      const partId = action.partId;
      return {
        ...state,
        partsAddedToFavorites: state.partsAddedToFavorites.filter(
          p => p !== partId
        ),
      };
    }
    case ADD_PRICE_TO_TOTAL: {
      const id = action.id;
      const price = state.parts.find(part => part.partModelId === id).price;
      const newTotal = state.totalSum + price;
      return {
        ...state,
        totalSum: newTotal,
      };
    }
    case CHANGE_QUANTITY: {
      const id = action.id;
      const newQuantity = action.quantity;
      return {
        ...state,
        partsAddedToCart: state.partsAddedToCart.map(part =>
          part.partId === id ? { partId: id, quantity: newQuantity } : part
        ),
      };
    }
    default:
      return state;
  }
}
