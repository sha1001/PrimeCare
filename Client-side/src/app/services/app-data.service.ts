import { Injectable } from '@angular/core';

import { Ord } from '../view-models/Ord';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';

@Injectable()
export class AppDataService {

  ords: Ord[] = [
    {
      ordNumber: 1,
      ordItem:
      [
        {
          name: 'Urethroscopy1Nitin',
          color: 'green',
          height: 100,
          width: 200,
          px: 0,
        },
        {
          name: 'Urethroscopy2',
          color: 'green',
          height: 100,
          width: 200,
          px: 370
        },
        {
          name: 'Urethroscopy3',
          color: 'green',
          height: 100,
          width: 200,
          px: 660
        }
      ]
    },
    {
      ordNumber: 2,
      ordItem:
      [
        {
          name: 'Ter',
          color: 'red',
          height: 100,
          width: 200,
          px: 0
        },
        {
          name: 'rer',
          color: 'red',
          height: 100,
          width: 200,
          px: 270
        }
      ]
    },
    {
      ordNumber: 3,
      ordItem:
      [
        {
          name: 'Ter',
          color: 'red',
          height: 100,
          width: 200,
          px: 50
        },
        {
          name: 'rer',
          color: 'red',
          height: 100,
          width: 200,
          px: 270
        },
        {
          name: 'Urethroscopy2',
          color: 'green',
          height: 100,
          width: 200,
          px: 600
        },
        {
          name: 'Urethroscopy3',
          color: 'green',
          height: 100,
          width: 200,
          px: 1090
        }

      ]
    },
    {
      ordNumber: 4,
      ordItem:
      [
        {
          name: 'Ter',
          color: 'red',
          height: 100,
          width: 200,
          px: 50
        },
        {
          name: 'rer',
          color: 'red',
          height: 100,
          width: 200,
          px: 270
        }
      ]
    },
    {
      ordNumber: 5,
      ordItem:
      [
        {
          name: 'Ter',
          color: 'red',
          height: 100,
          width: 200,
          px: 50
        },
        {
          name: 'rer',
          color: 'red',
          height: 100,
          width: 200,
          px: 270
        },
        {
          name: 'Urethroscopy2',
          color: 'green',
          height: 100,
          width: 200,
          px: 570
        },
        {
          name: 'Urethroscopy3',
          color: 'green',
          height: 100,
          width: 200,
          px: 1170
        }
      ]
    },
    {
      ordNumber: 6,
      ordItem:
      [
        {
          name: 'Ter',
          color: 'red',
          height: 100,
          width: 200,
          px: 50
        },
        {
          name: 'rer',
          color: 'red',
          height: 100,
          width: 200,
          px: 270
        }
      ]
    }
  ];
}
