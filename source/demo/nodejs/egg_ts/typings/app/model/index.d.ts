// This file is created by egg-ts-helper@1.25.8
// Do not modify this file!!!!!!!!!

import 'egg';
import ExportPerson from '../../../app/model/person';

declare module 'egg' {
  interface IModel {
    Person: ReturnType<typeof ExportPerson>;
  }
}
