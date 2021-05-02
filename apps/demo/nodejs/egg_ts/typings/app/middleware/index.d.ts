// This file is created by egg-ts-helper@1.25.8
// Do not modify this file!!!!!!!!!

import 'egg';
import ExportError from '../../../app/middleware/error';
import ExportTransaction from '../../../app/middleware/transaction';

declare module 'egg' {
  interface IMiddleware {
    error: typeof ExportError;
    transaction: typeof ExportTransaction;
  }
}
