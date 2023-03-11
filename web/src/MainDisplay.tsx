import { useState } from 'react';
import { z } from 'zod';
import { ItemMessage } from './ZodObjects';

export type Data = z.infer<typeof ItemMessage>;

interface MainProps {
  data: Data[];
}

//return keys of Data object - just placeholder, not scalable
const getDataKeys = () => {
  return Object.keys({
    uid: '',
    title: '',
    description: '',
    serialNumber: '',
    dateCreated: 0,
  });
};

const isDate = (columnName: string) => {
  return columnName.toLowerCase().includes('date');
};

const MainDisplay = ({ data }: MainProps) => {
  const [expanded, setExpanded] = useState(false);

  const sidebar = ['Alpha', 'Bravo', 'Charlie', 'Delta', 'Echo', 'Foxtrot'];

  return (
    <div
      className={`grid h-screen max-h-screen w-screen max-w-full grid-rows-[48px_1fr_40px] ${
        expanded ? 'grid-cols-[240px_1fr]' : 'grid-cols-[64px_1fr]'
      } overflow-x-hidden transition-all duration-300`}
    >
      {/* header */}
      <div className="col-span-2 col-start-1 flex min-w-full items-center justify-center bg-slate-800 ">
        <span className="text-xl font-bold">Application Title</span>
      </div>

      {/* sidebar */}
      <div className="col-start-1 flex-col overflow-y-auto border-b border-slate-500 bg-slate-600">
        {sidebar.map((v) => (
          <div
            key={v}
            title={expanded ? '' : v}
            className="my-2 cursor-pointer select-none text-center"
          >
            <span className="text-xl font-bold">
              {expanded ? v : v.charAt(0)}
            </span>
          </div>
        ))}
      </div>

      {/* expansion control */}
      <div
        className="col-start-1 row-start-3 flex h-10 cursor-pointer select-none items-center justify-center border-t border-slate-500 bg-slate-600"
        onClick={() => setExpanded((v) => !v)}
      >
        <span className="text-xl font-bold text-slate-200">
          {expanded ? '<<' : '>>'}
        </span>
      </div>

      {/* table holder, overflow this one */}
      <div className="<min-w-full col-start-2 max-h-full overflow-x-auto bg-slate-400">
        <table className="min-w-full table-auto">
          <thead className="sticky top-0 bg-slate-500">
            <tr>
              {getDataKeys().map((columnHeader) => (
                <td key={`${columnHeader}`}>{columnHeader}</td>
              ))}
            </tr>
          </thead>
          <tbody className="overflow-y-auto">
            {data.map((row) => (
              <tr key={`${row.uid}`}>
                {Object.keys(row).map((cell) => (
                  <td key={`${row.uid}-${cell}`}>
                    {isDate(cell)
                      ? new Date(Object(row)[cell]).toLocaleDateString()
                      : Object(row)[cell]}
                  </td>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      {/* table footer */}
      <div className=" col-start-2 flex max-h-10 min-w-full items-center bg-slate-500">
        <span className="grow"></span>
        <span className="mx-4">[ 100 ]</span>
        <span className="mx-4">{'|<  <  1/1  >  >|'}</span>
      </div>
    </div>
  );
};

export default MainDisplay;
