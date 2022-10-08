export interface AssignedCourse {
  id: string;
  title: string;
  description: string;
  additionalInformation?: any;
  credits: number;
  minimumGrade: number;
  hours: number;
}

export interface ProgramStructure {
  id: string;
  programId: string;
  programTitle: string;
  title: string;
  totalHours: number;
  totalCredits: number;
  createdAt: string;
  assignedCourses: AssignedCourse[];
}

export interface Offer {
  id: string;
  admissionAvailableUntil: string;
  startingOn: string;
  pricePerCredit: number;
  admissionsQuota: number;
  createdAt: Date;
  programStructure: ProgramStructure;
}
